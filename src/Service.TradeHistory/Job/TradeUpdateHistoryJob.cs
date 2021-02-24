using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Grpc.Core.Logging;
using ME.Contracts.OutgoingMessages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyJetWallet.Domain.Orders;
using Newtonsoft.Json;
using Service.TradeHistory.Domain.Models;
using Service.TradeHistory.Postgres;

namespace Service.TradeHistory.Job.Job
{
    public class TradeUpdateHistoryJob
    {
        private readonly ILogger<TradeUpdateHistoryJob> _logger;
        private readonly DbContextOptionsBuilder<DatabaseContext> _dbContextOptionsBuilder;

        public TradeUpdateHistoryJob(ISubscriber<IReadOnlyList<ME.Contracts.OutgoingMessages.OutgoingEvent>> subscriber,
            ILogger<TradeUpdateHistoryJob> logger,
            DbContextOptionsBuilder<DatabaseContext> dbContextOptionsBuilder)
        {
            _logger = logger;
            _dbContextOptionsBuilder = dbContextOptionsBuilder;
            subscriber.Subscribe(HandleEvents);
        }

        private async ValueTask HandleEvents(IReadOnlyList<ME.Contracts.OutgoingMessages.OutgoingEvent> events)
        {
            try
            {
                var trades = events
                    .SelectMany(e => e.Orders.Select(i => new {e.Header.SequenceNumber, Order = i}))
                    .Where(e => e.Order.Trades.Any())
                    .ToList();

                var list = new List<TradeHistoryEntity>();

                foreach (var order in trades)
                {
                    var baseVolume = order.Order.Trades.Sum(e => decimal.Parse(e.BaseVolume));
                    var quoteVolume = order.Order.Trades.Sum(e => decimal.Parse(e.QuotingVolume));
                    var price = Math.Abs(quoteVolume / baseVolume);
                    var tradeId = $"{order.Order.Id}-{order.SequenceNumber}";
                    var walletId = order.Order.WalletId;
                    var side = order.Order.Side;

                    Console.WriteLine($"{tradeId}[{walletId}] {side} {baseVolume} for {quoteVolume} price: {price}");

                    var item = new TradeHistoryEntity(
                        tradeId, order.Order.AssetPairId, (double) price, (double) baseVolume, (double) quoteVolume,
                        order.Order.Id,
                        MapOrderType(order.Order.OrderType), double.Parse(order.Order.Volume),
                        order.Order.LastMatchTime.ToDateTime(),
                        0, order.SequenceNumber, order.Order.BrokerId, order.Order.AccountId, order.Order.WalletId);

                    list.Add(item);
                }

                await using var ctx = new DatabaseContext(_dbContextOptionsBuilder.Options);
                await ctx.Trades.AddRangeAsync(list);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cannot Handle event from ME: {eventText}", JsonConvert.SerializeObject(events));
                throw;
            }
        }

        private OrderType MapOrderType(Order.Types.OrderType orderType)
        {
            switch (orderType)
            {
                case Order.Types.OrderType.Limit: return OrderType.Limit;
                case Order.Types.OrderType.Market: return OrderType.Market;
                case Order.Types.OrderType.StopLimit: return OrderType.StopLimit;
            }

            return OrderType.UnknownOrderType;
        }
    }
}
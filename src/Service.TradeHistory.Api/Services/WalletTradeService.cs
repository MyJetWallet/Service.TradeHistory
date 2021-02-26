﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.TradeHistory.Domain.Models;
using Service.TradeHistory.Grpc;
using Service.TradeHistory.Grpc.Models;
using Service.TradeHistory.Postgres;

namespace Service.TradeHistory.Api.Services
{
    public class WalletTradeService : IWalletTradeService
    {
        public const int DefaultTakeValue = 50;

        private readonly ILogger<WalletTradeService> _logger;
        private readonly DbContextOptionsBuilder<DatabaseContext> _dbContextOptionsBuilder;

        public WalletTradeService(ILogger<WalletTradeService> logger, DbContextOptionsBuilder<DatabaseContext> dbContextOptionsBuilder)
        {
            _logger = logger;
            _dbContextOptionsBuilder = dbContextOptionsBuilder;
        }

        public async Task<WalletTradeList> GetTradesAsync(GetTradesRequest request)
        {
            var take = request.Take ?? DefaultTakeValue;

            try
            {
                await using var ctx = new DatabaseContext(_dbContextOptionsBuilder.Options);

                var data = ctx.Trades.Where(e => e.WalletId == request.WalletId);

                if (request.LastSequenceId.HasValue)
                {
                    data = data.Where(e => e.SequenceId < request.LastSequenceId);
                }

                if (string.IsNullOrEmpty(request.Symbol))
                {
                    data = data.Where(e => e.InstrumentSymbol == request.Symbol);
                }

                data = data.OrderByDescending(e => e.SequenceId).Take(take);

                var list = await data.ToListAsync();

                var resp = new WalletTradeList {Trades = new List<WalletTrade>()};
                resp.Trades.AddRange(list.Select(e => new WalletTrade(e)));

                return resp;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Cannot get trades for walletId: {walletId}, take: {takeValue}, LastSequenceId: {LastSequenceId}",
                    request.WalletId, take, request.LastSequenceId);

                throw;
            }
        }

        public async Task<WalletTradeList> GetSingleTradesAsync(GetSingleTradesRequest request)
        {
            try
            {
                await using var ctx = new DatabaseContext(_dbContextOptionsBuilder.Options);

                var trade = await ctx.Trades.FirstOrDefaultAsync(e => e.TradeUId == request.TradeUid);

                var resp = new WalletTradeList { Trades = new List<WalletTrade>() };
                if (trade != null)
                {
                    resp.Trades.Add(new WalletTrade(trade));
                }

                return resp;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Cannot get trades with UID: {tradeUId}", request.TradeUid);

                throw;
            }
        }
    }
}

using System;
using MyJetWallet.Domain.Orders;
using Service.TradeHistory.Domain.Models;

namespace Service.TradeHistory.Postgres
{
    public class TradeHistoryEntity: WalletTrader
    {
        public TradeHistoryEntity(string tradeUId, string instrumentSymbol, double price, double baseVolume, double quoteVolume, 
            string orderId, OrderType type, double orderVolume, DateTime dateTime, long tradeId, long sequenceId, string brokerId, string clientId, string walletId) 
                : base(tradeUId, instrumentSymbol, price, baseVolume, quoteVolume, orderId, type, orderVolume, dateTime, tradeId, sequenceId)
        {
            BrokerId = brokerId;
            ClientId = clientId;
            WalletId = walletId;
        }

        public TradeHistoryEntity()
        {
        }

        public string BrokerId { get; set; }

        public string ClientId { get; set; }

        public string WalletId { get; set; }
    }
}
using System;
using MyJetWallet.Domain.Orders;
using Service.TradeHistory.Domain.Models;

namespace Service.TradeHistory.Postgres
{
    public class TradeHistoryEntity: WalletTrader
    {
        public TradeHistoryEntity(string tradeId, string instrumentSymbol, double price, double baseVolume, double quoteVolume, 
            string orderId, OrderType type, double orderVolume, DateTime dateTime, long tradeNo, long sequenceId, string brokerId, string accountId, string walletId) 
                : base(tradeId, instrumentSymbol, price, baseVolume, quoteVolume, orderId, type, orderVolume, dateTime, tradeNo, sequenceId)
        {
            BrokerId = brokerId;
            AccountId = accountId;
            WalletId = walletId;
        }

        public TradeHistoryEntity()
        {
        }

        public string BrokerId { get; set; }

        public string AccountId { get; set; }

        public string WalletId { get; set; }
    }
}
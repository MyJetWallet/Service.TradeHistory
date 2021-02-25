using System;
using System.Runtime.Serialization;
using MyJetWallet.Domain.Orders;

namespace Service.TradeHistory.Domain.Models
{
    [DataContract]
    public class WalletTrader
    {
        public WalletTrader(string tradeUId, string instrumentSymbol, double price, double baseVolume, double quoteVolume, string orderId, OrderType type, 
            double orderVolume, DateTime dateTime, long tradeId, long sequenceId)
        {
            TradeUId = tradeUId;
            InstrumentSymbol = instrumentSymbol;
            Price = price;
            BaseVolume = baseVolume;
            QuoteVolume = quoteVolume;
            OrderId = orderId;
            Type = type;
            OrderVolume = orderVolume;
            DateTime = dateTime;
            TradeId = tradeId;
            SequenceId = sequenceId;
        }

        public WalletTrader()
        {
        }

        [DataMember(Order = 1)]
        public long TradeId { get; set; }

        [DataMember(Order = 2)]
        public string InstrumentSymbol { get; set; }

        [DataMember(Order = 3)]
        public double Price { get; set; }

        [DataMember(Order = 4)]
        public double BaseVolume { get; set; }

        [DataMember(Order = 5)]
        public double QuoteVolume { get; set; }

        [DataMember(Order = 6)]
        public string OrderId { get; set; }

        [DataMember(Order = 7)]
        public OrderType Type { get; set; }

        [DataMember(Order = 8)]
        public double OrderVolume { get; set; }

        [DataMember(Order = 9)]
        public DateTime DateTime { get; set; }

        [DataMember(Order = 10)] 
        public string TradeUId { get; set; }

        [DataMember(Order = 11)]
        public long SequenceId { get; set; }
    }
}
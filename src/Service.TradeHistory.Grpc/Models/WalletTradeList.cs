using System.Collections.Generic;
using System.Runtime.Serialization;
using Service.TradeHistory.Domain.Models;

namespace Service.TradeHistory.Grpc.Models
{
    [DataContract]
    public class WalletTradeList
    {
        [DataMember(Order = 1)] public List<WalletTrade> Trades { get; set; } = new();
    }
}
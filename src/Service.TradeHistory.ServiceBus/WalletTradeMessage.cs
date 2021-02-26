﻿using System.Runtime.Serialization;
using Service.TradeHistory.Domain.Models;

namespace Service.TradeHistory.ServiceBus
{
    [DataContract]
    public class WalletTradeMessage
    {
        [DataMember(Order = 1)] public string BrokerId { get; set; }
        [DataMember(Order = 2)] public string ClientId { get; set; }
        [DataMember(Order = 3)] public string WalletId { get; set; }
        [DataMember(Order = 4)] public WalletTrade Trade { get; set; }
    }
}
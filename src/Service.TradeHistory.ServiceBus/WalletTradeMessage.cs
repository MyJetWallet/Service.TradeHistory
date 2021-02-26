using System.Runtime.Serialization;
using Service.TradeHistory.Domain.Models;

namespace Service.TradeHistory.ServiceBus
{
    [DataContract]
    public class WalletTradeMessage
    {
        [DataMember] public string BrokerId { get; set; }
        [DataMember] public string ClientId { get; set; }
        [DataMember] public string WalletId { get; set; }
        [DataMember] public WalletTrade Trade { get; set; }
    }
}
using System.Runtime.Serialization;

namespace Service.TradeHistory.Grpc.Models
{
    [DataContract]
    public class GetTradesRequest
    {
        [DataMember(Order = 1)] public string WalletId { get; set; }
        [DataMember(Order = 2)] public int? Take { get; set; }
        [DataMember(Order = 3)] public int? LastSequenceId { get; set; }
    }
}
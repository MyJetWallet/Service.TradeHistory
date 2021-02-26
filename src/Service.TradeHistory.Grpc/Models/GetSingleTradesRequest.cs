using System.Runtime.Serialization;

namespace Service.TradeHistory.Grpc.Models
{
    [DataContract]
    public class GetSingleTradesRequest
    {
        [DataMember(Order = 1)] public string TradeUid { get; set; }
    }
}
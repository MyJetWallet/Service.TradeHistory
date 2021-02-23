using System.Runtime.Serialization;
using Service.TradeHistory.Domain.Models;

namespace Service.TradeHistory.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}
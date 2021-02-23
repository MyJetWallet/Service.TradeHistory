using System.ServiceModel;
using System.Threading.Tasks;
using Service.TradeHistory.Grpc.Models;

namespace Service.TradeHistory.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}
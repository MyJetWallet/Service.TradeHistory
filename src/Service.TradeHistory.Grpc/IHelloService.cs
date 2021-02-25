using System.ServiceModel;
using System.Threading.Tasks;
using Service.TradeHistory.Grpc.Models;

namespace Service.TradeHistory.Grpc
{
    [ServiceContract]
    public interface IWalletTradeService
    {
        [OperationContract]
        Task<WalletTradeList> GetTradesAsync(GetTradesRequest request);
    }
}
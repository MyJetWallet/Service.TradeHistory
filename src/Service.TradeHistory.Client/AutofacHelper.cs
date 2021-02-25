using Autofac;
using Service.TradeHistory.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.TradeHistory.Client
{
    public static class AutofacHelper
    {
        public static void RegisterTradeHistoryClient(this ContainerBuilder builder, string tradeHistoryGrpcServiceUrl)
        {
            var factory = new TradeHistoryClientFactory(tradeHistoryGrpcServiceUrl);

            builder.RegisterInstance(factory.GetWalletTradeService()).As<IWalletTradeService>().SingleInstance();
        }
    }
}
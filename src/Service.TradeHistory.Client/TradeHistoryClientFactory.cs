using System;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using JetBrains.Annotations;
using MyJetWallet.Sdk.GrpcMetrics;
using ProtoBuf.Grpc.Client;
using Service.TradeHistory.Grpc;

namespace Service.TradeHistory.Client
{
    [UsedImplicitly]
    public class TradeHistoryClientFactory
    {
        private readonly CallInvoker _channel;

        public TradeHistoryClientFactory(string assetsDictionaryGrpcServiceUrl)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(assetsDictionaryGrpcServiceUrl);
            _channel = channel.Intercept(new PrometheusMetricsInterceptor());
        }

        public IWalletTradeService GetWalletTradeService() => _channel.CreateGrpcService<IWalletTradeService>();
    }


}

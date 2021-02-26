using Autofac;
using DotNetCoreDecorators;
using MyServiceBus.TcpClient;
using Service.TradeHistory.Domain.Models;
using Service.TradeHistory.Grpc;
using Service.TradeHistory.ServiceBus;

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

        public static void RegisterTradeHistoryServiceBusClient(this ContainerBuilder builder, MyServiceBusTcpClient client, string queueName, bool deleteOnDisconnect)
        {
            builder
                .RegisterInstance(new WalletTradeServiceBusSubscriber(client, queueName, deleteOnDisconnect))
                .As<ISubscriber<WalletTrade>>()
                .SingleInstance();
        }
    }
}
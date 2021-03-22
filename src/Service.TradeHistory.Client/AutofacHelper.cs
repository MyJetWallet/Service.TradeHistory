using System.Collections.Generic;
using Autofac;
using DotNetCoreDecorators;
using MyServiceBus.Abstractions;
using MyServiceBus.TcpClient;
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

        public static void RegisterTradeHistoryServiceBusClient(this ContainerBuilder builder, MyServiceBusTcpClient client, string queueName, TopicQueueType queryType, bool batchSubscriber)
        {
            if (batchSubscriber)
            {
                builder
                    .RegisterInstance(new WalletTradeServiceBusSubscriber(client, queueName, queryType, true))
                    .As<ISubscriber<IReadOnlyList<WalletTradeMessage>>>()
                    .SingleInstance();
            }
            else
            {
                builder
                    .RegisterInstance(new WalletTradeServiceBusSubscriber(client, queueName, queryType, false))
                    .As<ISubscriber<WalletTradeMessage>>()
                    .SingleInstance();
            }
        }
    }
}
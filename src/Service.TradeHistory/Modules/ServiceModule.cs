using System;
using Autofac;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.Service;
using MyServiceBus.TcpClient;
using Newtonsoft.Json;
using Service.MatchingEngine.EventBridge.ServiceBus;
using Service.TradeHistory.Job.Job;

namespace Service.TradeHistory.Job.Modules
{
    public class ServiceModule: Module
    {
        public static ILogger ServiceBusLogger { get; private set; }

        protected override void Load(ContainerBuilder builder)
        {
            ServiceBusLogger = Program.LogFactory.CreateLogger(nameof(MyServiceBusTcpClient));
            
            var serviceBusClient = new MyServiceBusTcpClient(Program.ReloadedSettings(e => e.SpotServiceBusHostPort), ApplicationEnvironment.HostName);
            serviceBusClient.PlugPacketHandleExceptions(ex => ServiceBusLogger.LogError(ex as Exception, "Exception in MyServiceBusTcpClient"));
            serviceBusClient.PlugSocketLogs((context, msg) => ServiceBusLogger.LogInformation($"MyServiceBusTcpClient[Socket {context?.Id}|{context?.Connected}|{context?.Inited}] {msg}"));


            builder.RegisterInstance(serviceBusClient).AsSelf().SingleInstance();
            builder.RegisterMeEventSubscriber(serviceBusClient, "trade-history", false);

            builder.RegisterType<TradeUpdateHistoryJob>().AutoActivate().SingleInstance();
        }
    }
}
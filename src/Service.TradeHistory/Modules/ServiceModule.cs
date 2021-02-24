using Autofac;
using MyJetWallet.Sdk.Service;
using MyServiceBus.TcpClient;
using Service.MatchingEngine.EventBridge.ServiceBus;
using Service.TradeHistory.Job.Job;

namespace Service.TradeHistory.Job.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var serviceBusClient = new MyServiceBusTcpClient(Program.ReloadedSettings(e => e.SpotServiceBusHostPort), ApplicationEnvironment.HostName);
            builder.RegisterInstance(serviceBusClient).AsSelf().SingleInstance();
            builder.RegisterMeEventSubscriber(serviceBusClient, "trade-history", false);

            builder.RegisterType<TradeUpdateHistoryJob>().AutoActivate().SingleInstance();
        }
    }
}
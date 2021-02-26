using JetBrains.Annotations;
using MyJetWallet.Domain.ServiceBus;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.TcpClient;
using Service.TradeHistory.Domain.Models;

namespace Service.TradeHistory.ServiceBus
{
    [UsedImplicitly]
    public class WalletTradeServiceBusSubscriber : Subscriber<WalletTrade>
    {
        public WalletTradeServiceBusSubscriber(MyServiceBusTcpClient client, string queueName, bool deleteOnDisconnect) :
            base(client, WalletTradeServiceBusPublisher.TopicName, queueName, deleteOnDisconnect,
                bytes => bytes.ByteArrayToServiceBusContract<WalletTrade>())
        {

        }
    }
}
using System.Threading.Tasks;
using DotNetCoreDecorators;
using JetBrains.Annotations;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.TcpClient;
using Service.TradeHistory.Domain.Models;

namespace Service.TradeHistory.ServiceBus
{
    [UsedImplicitly]
    public class WalletTradeServiceBusPublisher : IPublisher<WalletTrade>
    {
        public const string TopicName = "spot-trades";

        private readonly MyServiceBusTcpClient _client;

        public WalletTradeServiceBusPublisher(MyServiceBusTcpClient client)
        {
            _client = client;
            _client.CreateTopicIfNotExists(TopicName, 10000);
        }

        public async ValueTask PublishAsync(WalletTrade valueToPublish)
        {
            var bytesToSend = valueToPublish.ServiceBusContractToByteArray();
            await _client.PublishAsync(TopicName, bytesToSend, true);
        }
    }
}
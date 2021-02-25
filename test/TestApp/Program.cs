using System;
using System.Threading.Tasks;
using ProtoBuf.Grpc.Client;
using Service.TradeHistory.Client;
using Service.TradeHistory.Grpc.Models;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;

            Console.Write("Press enter to start");
            Console.ReadLine();


            var factory = new TradeHistoryClientFactory("http://localhost:80");
            var client = factory.GetWalletTradeService();

            var resp = await  client.GetTradesAsync(new GetTradesRequest(){WalletId = "test--default", Take = 5});
            foreach (var trade in resp.Trades)
            {
                Console.WriteLine($"trade {trade.InstrumentSymbol} {trade.Side} {trade.BaseVolume} to {trade.QuoteVolume} | {trade.TradeUId}");
            }

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}

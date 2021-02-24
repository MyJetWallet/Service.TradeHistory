using SimpleTrading.SettingsReader;

namespace Service.TradeHistory.Job.Settings
{
    [YamlAttributesOnly]
    public class SettingsModel
    {
        [YamlProperty("TradeHistory.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("TradeHistory.PostgresConnectionString")]
        public string PostgresConnectionString { get; set; }

        [YamlProperty("TradeHistory.SpotServiceBusHostPort")]
        public string SpotServiceBusHostPort { get; set; }
    }
}
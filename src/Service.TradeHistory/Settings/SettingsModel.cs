using SimpleTrading.SettingsReader;

namespace Service.TradeHistory.Settings
{
    [YamlAttributesOnly]
    public class SettingsModel
    {
        [YamlProperty("TradeHistory.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }
    }
}
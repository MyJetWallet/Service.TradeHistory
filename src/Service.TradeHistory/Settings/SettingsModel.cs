﻿using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.TradeHistory.Job.Settings
{
    public class SettingsModel
    {
        [YamlProperty("TradeHistory.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("TradeHistory.PostgresConnectionString")]
        public string PostgresConnectionString { get; set; }

        [YamlProperty("TradeHistory.SpotServiceBusHostPort")]
        public string SpotServiceBusHostPort { get; set; }
        
        [YamlProperty("TradeHistory.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("TradeHistory.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
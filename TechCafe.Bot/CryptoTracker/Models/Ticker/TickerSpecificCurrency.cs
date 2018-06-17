using Newtonsoft.Json;

namespace TechCafe.Bot.CryptoTracker.Models.Ticker
{
    public class TickerSpecificCurrency
    {
        [JsonProperty("data")]
        public CoinInfo Data { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }
}
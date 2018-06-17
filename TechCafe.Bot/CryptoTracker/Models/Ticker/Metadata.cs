using Newtonsoft.Json;

namespace TechCafe.Bot.CryptoTracker.Models.Ticker
{
    public class Metadata
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
using Newtonsoft.Json;

namespace TechCafe.Bot.CryptoTracker.Models.Ticker
{
    public class Quote
    {
        [JsonProperty("USD")]
        public QuoteUsd Usd { get; set; }
    }
}
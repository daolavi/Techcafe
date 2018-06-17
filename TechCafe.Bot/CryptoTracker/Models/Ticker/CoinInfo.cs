using Newtonsoft.Json;

namespace TechCafe.Bot.CryptoTracker.Models.Ticker
{
    public class CoinInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("website_slug")]
        public string WebsiteSlug { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("circulating_supply")]
        public long CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public long TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public long MaxSupply { get; set; }

        [JsonProperty("quotes")]
        public Quote Quote { get; set; }

        [JsonProperty("last_updated")]
        public long LastUpdated { get; set; }
    }
}
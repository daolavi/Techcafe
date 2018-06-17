using Newtonsoft.Json;

namespace TechCafe.Bot.WC2018.Models
{
    public class Stadium
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
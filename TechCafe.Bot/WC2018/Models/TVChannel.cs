using Newtonsoft.Json;
using System.Collections.Generic;

namespace TechCafe.Bot.WC2018.Models
{
    public class TVChannel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("iso2")]
        public string Iso2 { get; set; }

        [JsonProperty("lang")]
        public List<string> Lang { get; set; }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TechCafe.Bot.WC2018.Models
{
    public class Round
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("matches")]
        public List<Match> Matches { get; set; }
    }
}
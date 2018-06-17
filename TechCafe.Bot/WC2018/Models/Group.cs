using System.Collections.Generic;
using Newtonsoft.Json;

namespace TechCafe.Bot.WC2018.Models
{
    public class Group
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("winner")]
        public int? Winner { get; set; }

        [JsonProperty("runnerup")]
        public int? RunnerUp { get; set; }

        [JsonProperty("matches")]
        public List<Match> Matches { get; set; }
    }
}
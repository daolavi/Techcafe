using System.Collections.Generic;
using Newtonsoft.Json;

namespace TechCafe.Bot.WC2018.Models
{
    public class Data
    {
        [JsonProperty("stadiums")]
        public List<Stadium> Stadiums { get; set; }

        [JsonProperty("tvchannels")]

        public List<TVChannel> TVChannels { get; set; }

        [JsonProperty("teams")]

        public List<Team> Teams { get; set; }

        [JsonProperty("groups")]

        public Groups Groups { get; set; }

        [JsonProperty("knockout")]

        public Knockout Knockout { get; set; }
    }
}
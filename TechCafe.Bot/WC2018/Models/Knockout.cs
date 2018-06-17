using Newtonsoft.Json;

namespace TechCafe.Bot.WC2018.Models
{
    public class Knockout
    {
        [JsonProperty("round_16")]
        public Round Round16 { get; set; }

        [JsonProperty("round_8")]
        public Round Round8 { get; set; }

        [JsonProperty("round_4")]
        public Round Round4 { get; set; }

        [JsonProperty("round_2_loser")]
        public Round Round2Loser { get; set; }

        [JsonProperty("round_2")]
        public Round Round2 { get; set; }
    }
}
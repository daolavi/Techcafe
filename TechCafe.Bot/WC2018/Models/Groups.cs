using Newtonsoft.Json;

namespace TechCafe.Bot.WC2018.Models
{
    public class Groups
    {
        [JsonProperty("a")]
        public Group A { get; set; }

        [JsonProperty("b")]
        public Group B { get; set; }

        [JsonProperty("c")]
        public Group C { get; set; }

        [JsonProperty("d")]
        public Group D { get; set; }

        [JsonProperty("e")]
        public Group E { get; set; }

        [JsonProperty("f")]
        public Group F { get; set; }

        [JsonProperty("g")]
        public Group G { get; set; }

        [JsonProperty("h")]
        public Group H { get; set; }

    }
}
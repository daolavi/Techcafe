using Newtonsoft.Json;

namespace TechCafe.Bot.WC2018.Models
{
    public class Team
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fifaCode")]
        public string FifaCode { get; set; }

        [JsonProperty("iso2")]
        public string Iso2 { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("emoji")]
        public string Emoji { get; set; }

        [JsonProperty("emojiString")]
        public string EmojiString { get; set; }
    }
}
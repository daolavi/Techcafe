using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TechCafe.Bot.WC2018.Models
{
    public class Match
    {
        [JsonProperty("name")]
        public int Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("home_team")]
        public string HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public string AwayTeam { get; set; }

        [JsonProperty("home_result")]
        public int? HomeResult { get; set; }

        [JsonProperty("away_result")]
        public int? AwayResult { get; set; }

        [JsonProperty("home_penalty")]
        public int? HomePenalty { get; set; }

        [JsonProperty("away_penalty")]
        public int? AwayPenalty { get; set; }

        [JsonProperty("winner")]
        public int Winner { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("stadium")]
        public int Stadium { get; set; }

        [JsonProperty("channels")]
        public List<int> Channels { get; set; }

        [JsonProperty("finished")]
        public bool Finished { get; set; }

        [JsonProperty("matchday")]
        public int MatchDay { get; set; }

        [JsonProperty("home_team_name")]
        public string HomeTeamName { get; set; }

        [JsonProperty("away_team_name")]
        public string AwayTeamName { get; set; }

        [JsonProperty("stadium_name")]
        public string StadiumName { get; set; }
    }
}
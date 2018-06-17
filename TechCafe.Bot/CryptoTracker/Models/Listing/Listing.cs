using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechCafe.Bot.CryptoTracker.Models.Listing
{
    public class Listing
    {
        [JsonProperty("data")]
        public List<CoinInfo> Data { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechCafe.Bot.CryptoTracker.Models.Listing
{
    public class Metadata
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("num_cryptocurrencies")]
        public int Num_CryptoCurrencies { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
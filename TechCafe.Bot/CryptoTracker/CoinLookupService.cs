using System;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using TechCafe.Bot.CryptoTracker.Models.Listing;
using System.Linq;

namespace TechCafe.Bot.CryptoTracker
{
    public sealed class CoinLookupService
    {
        private static readonly Lazy<CoinLookupService> lazy = new Lazy<CoinLookupService>(() => new CoinLookupService());

        public static CoinLookupService Instance { get { return lazy.Value; } }

        private Listing coinData;

        public CoinLookupService()
        {
            var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "CoinData", "Listing.json");
            var content = File.ReadAllText(filePath);
            coinData = JsonConvert.DeserializeObject<Listing>(content);
        }

        public CoinInfo Lookup(string searchParameter)
        {
            var lowerCaseParameter = searchParameter.ToLower();
            var coinInfo = coinData.Data.FirstOrDefault(x => lowerCaseParameter == x.Name.ToLower()  || lowerCaseParameter == x.Symbol.ToLower());
            return coinInfo;
        }
    }
}
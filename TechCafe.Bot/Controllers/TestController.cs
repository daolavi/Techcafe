using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TechCafe.Bot.CryptoTracker;
using TechCafe.Bot.WC2018;
using TechCafe.Bot.WC2018.Extension;
using TechCafe.Bot.WC2018.Models;

namespace TechCafe.Bot.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        /// <summary>
        /// GET: api/test/coin?searchParameter=btc
        /// </summary>
        /// <param name="searchParameter"></param>
        [HttpGet]
        [Route("coin")]
        public object GetCoin(string searchParameter)
        {
            var coinInfo = CoinLookupService.Instance.Lookup(searchParameter);
            if (coinInfo != null)
            {
                var data = CoinMarketCapService.Instance.GetCurrencyInfo(coinInfo.Id).Data;
                var result = $"{data.Name} : {data.Quote.Usd.Price:C} - Vol24h {data.Quote.Usd.Volume24h:C}";
                result += " - %change 1d " + (data.Quote.Usd.PercentChange24h >= 0 ? "(up) " : "(down) ") + data.Quote.Usd.PercentChange24h + " %";
                result += " - %change 7d " + (data.Quote.Usd.PercentChange7d >= 0 ? "(up) " : "(down) ") + data.Quote.Usd.PercentChange7d + " %";
                return result;
            }
            return ":)";
        }

        /// <summary>
        /// GET: api/test/wc18
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("wc18/nextmatches")]
        public object GetWC2018Match()
        {
            var matches = WC2018LookupService.Instance.GetNextMatches();            
            var matchesString = matches.Select(m => m.ToText()).ToArray();
            return string.Join("\n\n", matchesString);
        }

        [HttpGet]
        [Route("wc18/data")]
        public object GetWC2018LatestData()
        {
            List<Match> matches;
            List<Team> teams;
            List<Stadium> stadiums;
            var data = WC2018LookupService.Instance.GetLatestData(out matches, out teams, out stadiums);
            return data;
        }

        [HttpGet]
        [Route("wc18/scores")]
        public object GetScores()
        {
            var matches = WC2018LookupService.Instance.GetScores();
            var matchesString = matches.Select(m => m.ToScore()).ToArray();
            return string.Join("\n\n", matchesString);
        }
    }
}
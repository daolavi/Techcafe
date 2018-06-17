using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TechCafe.Bot.WC2018.Extension;
using TechCafe.Bot.WC2018.Models;
using RestSharp;
using TechCafe.Bot.JsonSerializer;

namespace TechCafe.Bot.WC2018
{
    public sealed class WC2018LookupService
    {
        private static readonly Lazy<WC2018LookupService> lazy = new Lazy<WC2018LookupService>(() => new WC2018LookupService());

        public static WC2018LookupService Instance { get { return lazy.Value; } }

        private RestClient client;

        private List<Match> matches;

        private List<Team> teams;

        private List<Stadium> stadiums;

        public WC2018LookupService()
        {
            /*
            var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "WC2018Data", "data.json");
            var content = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<Data>(content);
            */

            client = new RestClient("https://raw.githubusercontent.com");
            client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/x-json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/javascript", NewtonsoftJsonSerializer.Default);
            client.AddHandler("*+json", NewtonsoftJsonSerializer.Default);
        }

        public Data GetLatestData(out List<Match> matches, out List<Team> teams, out List<Stadium> stadiums)
        {
            var request = new RestRequest("lsv/fifa-worldcup-2018/master/data.json", Method.GET);
            var content = client.Execute(request).Content;
            var data = JsonConvert.DeserializeObject<Data>(content);

            matches = new List<Match>();
            matches.AddRange(data.Groups.A.Matches);
            matches.AddRange(data.Groups.B.Matches);
            matches.AddRange(data.Groups.C.Matches);
            matches.AddRange(data.Groups.D.Matches);
            matches.AddRange(data.Groups.E.Matches);
            matches.AddRange(data.Groups.F.Matches);
            matches.AddRange(data.Groups.G.Matches);
            matches.AddRange(data.Groups.H.Matches);
            matches.AddRange(data.Knockout.Round16.Matches);
            matches.AddRange(data.Knockout.Round8.Matches);
            matches.AddRange(data.Knockout.Round4.Matches);
            matches.AddRange(data.Knockout.Round2Loser.Matches);
            matches.AddRange(data.Knockout.Round2.Matches);

            teams = data.Teams;
            stadiums = data.Stadiums;

            return data;
        }

        public List<Match> GetNextMatches()
        {
            var data = GetLatestData(out matches, out teams, out stadiums);
            var result = matches.OrderBy(m => m.Date).Where(m => m.Date >= DateTime.Now).Take(3).Select(m => m.Fetch(teams,stadiums)).ToList();
            return result;
        }

        public List<Match> GetScores()
        {
            var data = GetLatestData(out matches, out teams, out stadiums);
            var result = matches.OrderByDescending(m => m.Date).Where(m => m.HomeResult.HasValue && m.AwayResult.HasValue).Take(3).Select(m => m.Fetch(teams, stadiums)).ToList();
            return result;
        }
    }
}
using System;
using RestSharp;
using TechCafe.Bot.CryptoTracker.Models.Ticker;
using TechCafe.Bot.JsonSerializer;

namespace TechCafe.Bot.CryptoTracker
{
    public sealed class CoinMarketCapService
    {
        private static readonly Lazy<CoinMarketCapService> lazy = new Lazy<CoinMarketCapService>(() => new CoinMarketCapService());

        public static CoinMarketCapService Instance { get { return lazy.Value; } }

        private RestClient client;

        public CoinMarketCapService()
        {
            client = new RestClient("https://api.coinmarketcap.com");
            client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/x-json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/javascript", NewtonsoftJsonSerializer.Default);
            client.AddHandler("*+json", NewtonsoftJsonSerializer.Default);
        }

        public TickerSpecificCurrency GetCurrencyInfo(int id)
        {
            var request = new RestRequest("v2/ticker/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<TickerSpecificCurrency>(request);
            return response.Data;
        }
    }
}
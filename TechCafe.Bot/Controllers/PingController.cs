using System.Web.Http;
using System;
using TechCafe.Bot.CryptoTracker;

namespace TechCafe.Bot
{
    [RoutePrefix("api/ping")]
    public class PingController : ApiController
    {
        /// <summary>
        /// GET: api/ping
        /// </summary>
        [HttpGet]
        public object Ping()
        {
            var serverTime = DateTime.Now;
            return serverTime;
        }
    }
}
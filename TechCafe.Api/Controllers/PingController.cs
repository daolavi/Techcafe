using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TechCafe.Api.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        private readonly ILogger logger;

        public PingController(ILogger<PingController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public JsonResult Ping()
        {
            var serverTime = DateTime.Now;
            var reponse = new 
            {
                ServerTime = serverTime,
            };
            logger.LogInformation($"Server time : {serverTime}");
            return new JsonResult(reponse);
        }
    }
}

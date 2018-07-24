using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TechCafe.Api.Controllers
{
    [Route("api/[controller]")]
    public class HttpClientController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        private readonly ILogger logger;

        public HttpClientController(IHttpClientFactory clientFactory, ILogger<HttpClientController> logger)
        {
            this.clientFactory = clientFactory;
            this.logger = logger;
        }


        [HttpGet]
        [Route("servermbstatus")]
        public async Task<object> ServerMBStatus()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://112.78.1.159:9100/fo/status");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "TechCafe-Api");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            return await response.Content.ReadAsAsync<object>();
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechCafe.Api.Models.Requests;
using TechCafe.Api.Services;

namespace TechCafe.Api.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IAuthenticationService authenticationService;

        public TokenController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = authenticationService.Authenticate(login.Username, login.Password);
            if (user != null)
            {
                var tokenString = authenticationService.BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}

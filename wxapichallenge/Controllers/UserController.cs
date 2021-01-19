using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace wxapichallenge.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// This API provides username and access token information 
        /// Result will be a JSON object in the format {"name": "test", "token" : "1234-455662-22233333-3333"}
        /// </summary>
        [HttpGet]
        public IActionResult GetToken()
        {
            return Ok(new {
                name = _config.GetValue<string>("UserName"),
                token = _config.GetValue<string>("UserToken")
            });
        }
    }
}
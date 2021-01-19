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
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationTestApp.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        [HttpPost("/register")]
        public async Task<IActionResult> Register() 
        {
            return Ok();
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login() 
        {
            return Ok();
        }
    }
}

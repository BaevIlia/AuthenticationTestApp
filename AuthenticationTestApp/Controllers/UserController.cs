using AuthenticationTestApp.Dtos;
using AuthenticationTestApp.Services;
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
        public async Task<IActionResult> Login(LoginUserRequest request, UserService userService) 
        {
            var token = await userService.Login(request.Email, request.Password);

            return Ok(token);
        }
    }
}

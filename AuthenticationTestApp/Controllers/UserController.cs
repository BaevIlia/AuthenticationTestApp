using AuthenticationTestApp.Dtos;
using AuthenticationTestApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationTestApp.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterUserRequest request) 
        {
            await _userService.Register(request.UserName, request.Email, request.Password);
            return Ok();
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginUserRequest request) 
        {
            var token = await _userService.Login(request.Email, request.Password);

            return Ok(token);
        }
    }
}

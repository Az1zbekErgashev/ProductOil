using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductOil.Dto;
using ProductOil.Enitiy;
using ProductOil.Servis.Auth;
using System.Security.Claims;
namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authService;
        private readonly UserManager<User> _userManager;
        public AuthController(IAuthRepository authService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _authService = authService;
        }
        [HttpGet, Authorize]
        public ActionResult<string> GetMyName() => Ok(CreateTokenInJwtAuthorizationFromUsers.GetMyId());
        [HttpGet("ListUsers"), Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _authService.GetAllUsers());
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request) => Ok(await _authService.Register(request));
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto request) => Ok(await _authService.Login(request));

    }
}

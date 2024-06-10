using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Selvox.BLL.Data_Objects;
using Selvox.BLL.Services;
using Selvox.DAL.Models;

namespace Selvox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            try
            {
                var user = await _userService.Register(userRegisterDto.Username, userRegisterDto.Email,userRegisterDto.Role,
                    userRegisterDto.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                var sessionId = await _userService.Login(userLoginDto.Username, userLoginDto.Password);
                return Ok(new { SessionId = sessionId });
                
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }
        
        [HttpPost("logout")]
        public IActionResult Logout([FromHeader] string sessionId)
        {
            _userService.Logout(sessionId);
            return Ok(new { message = "Logged out successfully" });
        }

        [HttpGet("me")]
        public IActionResult GetUser([FromHeader] string sessionId)
        {
            var user = _userService.GetUserBySessionId(sessionId);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid session" });
            }
            return Ok(user);
        }

        [HttpGet("checkRole")]
        public IActionResult CheckRole([FromHeader] string sessionId, [FromQuery] string role)
        {
            if (_userService.HasRole(sessionId, role))
            {
                return Ok(new { message = $"User has role: {role}" });
            }
            return Forbid($"User does not have role: {role}" );
        }
    }
}
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Selvox.BLL.DTOs;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Models;

namespace Selvox.BLL.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowLocalhost")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users.Any()) return Ok(users);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            var newUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO userUpdateDTO)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            existingUser.FirstName = userUpdateDTO.FirstName;
            existingUser.LastName = userUpdateDTO.LastName;
            existingUser.DateOfBirth = userUpdateDTO.DateOfBirth;
            existingUser.Gender = userUpdateDTO.Gender;

            if (!string.IsNullOrEmpty(userUpdateDTO.PasswordHash))
            {
                existingUser.PasswordHash = userUpdateDTO.PasswordHash;
            }

            var updatedUser = await _userService.UpdateUserAsync(existingUser);
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO registrationDto)
        {
            try
            {
                // Validate role
                if (!IsValidRole(registrationDto.Role))
                {
                    return BadRequest(new { message = "Invalid role. Allowed values: jobseeker, employer, admin" });
                }

                var user = new User
                {
                    FirstName = registrationDto.FirstName,
                    LastName = registrationDto.LastName,
                    Email = registrationDto.Email,
                    Role = registrationDto.Role, // Assign role from DTO
                    PasswordHash = registrationDto.PasswordHash
                };

                var createdUser = await _userService.RegisterUserAsync(user, registrationDto.PasswordHash);

                return Ok(new { message = "User registered successfully", userId = createdUser.UserId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDto)
        {
            var user = await _userService.AuthenticateUserAsync(userLoginDto.Email, userLoginDto.PasswordHash);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            var token = "dummy-jwt-token";

            return Ok(new { token, userId = user.UserId, role = user.Role });
        }

        private bool IsValidRole(string role)
        {
            // Define allowed roles
            var allowedRoles = new[] { "jobseeker", "employer", "admin" };
            return allowedRoles.Contains(role.ToLowerInvariant()); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deletedUser = await _userService.DeleteUserAsync(id);
            if (!deletedUser) return NotFound();
            return NoContent();
        }
    }
}

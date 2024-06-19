using Microsoft.AspNetCore.Mvc;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Models;

namespace Selvox.BLL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
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
        if (user == null)
            return NotFound();

        return Ok(user);
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> AddUser([FromBody] User user)
    {
        var newUser = await _userService.AddUserAsync(user);

        return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.UserId)
            return BadRequest();
        var updatedUser = await _userService.UpdateUserAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deletedUser = await _userService.DeleteUserAsync(id);
        if (!deletedUser)
            return NotFound();
        return NoContent();
    }
}
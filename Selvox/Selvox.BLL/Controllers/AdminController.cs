using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly SelvoxDbContext _selvoxDbContext;

    public AdminController(SelvoxDbContext selvoxDbContext)
    {
        _selvoxDbContext = selvoxDbContext;
    }

    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(int page = 1, int pageSize = 100)
    {
        return await _selvoxDbContext.Users
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _selvoxDbContext.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _selvoxDbContext.Users.Remove(user);
         await _selvoxDbContext.SaveChangesAsync();
         return NotFound();
    }

    [HttpGet("joblistings")]
    public async Task<ActionResult<IEnumerable<JobListing>>> GetAllJobs(int page = 1, int pageSize = 100)
    {
        return await _selvoxDbContext.JobListings
            .Include(jl => jl.Employer)
            .Include(jl => jl.JobRole)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
    [HttpDelete("jobseekers/{id}")]
    public async Task<IActionResult> DeleteJobs(int id)
    {
        var jobListing = await _selvoxDbContext.JobListings.FindAsync(id);

        if (jobListing == null)
        {
            return NotFound();
        }

        _selvoxDbContext.JobListings.Remove(jobListing);
        await _selvoxDbContext.SaveChangesAsync();
        return NotFound();
    }
}
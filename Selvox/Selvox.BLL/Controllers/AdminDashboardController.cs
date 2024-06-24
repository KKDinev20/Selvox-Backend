using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selvox.DAL.Context;

[ApiController]
[EnableCors("CorsPolicy")]
[Route("api/admin/dashboard-data")]
public class AdminDashboardController : ControllerBase
{
    private readonly SelvoxDbContext _context;

    public AdminDashboardController(SelvoxDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetDashboardData()
    {
        try
        {
            var jobseekerCount = await _context.Users.CountAsync(u => u.Role == "Jobseeker");
            var employerCount = await _context.Users.CountAsync(u => u.Role == "Employer");
            var totalCount = jobseekerCount + employerCount;

            var recentAccounts = await _context.Users
                .OrderByDescending(u => u.CreatedAt)
                .Take(10)
                .Select(u => new { u.UserId, u.FirstName, u.LastName, u.Email, u.CreatedAt })
                .ToListAsync();

            return Ok(new
            {
                jobseekerCount,
                employerCount,
                totalCount,
                recentAccounts
            });
        }
        catch (Exception ex)
        {
            // Log the error (you can use any logging library)
            Console.WriteLine($"Error fetching dashboard data: {ex.Message}");
            return StatusCode(500, "An error occurred while fetching dashboard data.");
        }
    }
}
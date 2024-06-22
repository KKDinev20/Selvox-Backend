using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobListingController : ControllerBase
{
    private readonly SelvoxDbContext _selvoxDbContext;

    public JobListingController(SelvoxDbContext selvoxDbContext)
    {
        _selvoxDbContext = selvoxDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobListing>>> GetJobListings()
    {
        return await _selvoxDbContext.JobListings
            .Include(jl => jl.Employer)
            .Include(jl => jl.JobRole)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<JobListing>> PostJobListings(JobListing jobListing)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        jobListing.PostedDate = DateTimeOffset.Now;
        jobListing.CreatedAt = DateTimeOffset.Now;
        jobListing.UpdatedAt = DateTimeOffset.Now;

        _selvoxDbContext.JobListings.Add(jobListing);
        await _selvoxDbContext.SaveChangesAsync();

        return CreatedAtAction("GetJobListing", new { id = jobListing.JobListingId, jobListing });
    }

}
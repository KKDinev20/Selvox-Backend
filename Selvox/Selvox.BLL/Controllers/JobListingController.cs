using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selvox.BLL.DTOs;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobListingController : ControllerBase
{
    private readonly IJobListingService _jobListingService;

    public JobListingController(IJobListingService jobListingService)
    {
        _jobListingService = jobListingService;
    }

    [HttpPost]
    [Route("PostJobListing")]
    public async Task<IActionResult> PostJobListing([FromBody] JobListingDTO jobListingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _jobListingService.AddJobListingAsync(jobListingDto);
            return Ok(new { Message = "Job listing posted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }
}
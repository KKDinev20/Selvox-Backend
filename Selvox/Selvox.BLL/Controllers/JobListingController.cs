using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Selvox.BLL.DTOs;
using Selvox.BLL.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Selvox.DAL.Models;

[ApiController]
[EnableCors()]
[Route("api/[controller]")]
public class JobListingController : ControllerBase
{
    private readonly IJobListingService _jobListingService;
    private readonly IUserService _userService;

    public JobListingController(IJobListingService jobListingService, IUserService userService)
    {
        _jobListingService = jobListingService;
        _userService = userService; 
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

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteJobListing(int id)
    {
        try
        {
            var jobListing = await _jobListingService.GetJobListingByIDAsync(id);

            if (jobListing == null)
            {
                return NotFound(new { Message = "Job listing not found." });
            }
            

            await _jobListingService.DeleteJobListingAsync(id);
            return Ok(new { Message = "Job listing deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateJobListing(int id, [FromBody] JobListingDTO jobListingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var jobListing = await _jobListingService.GetJobListingByIDAsync(id);

            if (jobListing == null)
            {
                return NotFound(new { Message = "Job listing not found." });
            }
            
            await _jobListingService.UpdateJobListingAsync(id, jobListingDto);
            return Ok(new { Message = "Job listing updated successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobListing>>> GetAllJobListings()
    {
        var jobListings = await _jobListingService.GetAllJobListingsAsync();
        return Ok(jobListings);
    }
}

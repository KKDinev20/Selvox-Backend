using Microsoft.AspNetCore.Mvc;
using Selvox.BLL.DTOs;
using Selvox.DAL.Models;
using Selvox.BLL.Interfaces;

namespace Selvox.BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOffersController : ControllerBase
    {
        private readonly IJobOfferService _jobOfferService;

        public JobOffersController(IJobOfferService jobOfferService)
        {
            _jobOfferService = jobOfferService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobOffer([FromBody] JobOfferDTO jobOfferDto)
        {
            try
            {
                var jobOffer = new JobListing
                {
                    EmployerId = jobOfferDto.EmployerId,
                    JobRoleId = jobOfferDto.JobRoleId,
                    JobTitle = jobOfferDto.JobTitle,
                    JobDescription = jobOfferDto.JobDescription,
                    Location = jobOfferDto.Location,
                    SalaryRange = jobOfferDto.SalaryRange,
                    PostedDate = jobOfferDto.PostedDate,
                    ExpirationDate = jobOfferDto.ExpirationDate,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                var createdJobOffer = await _jobOfferService.CreateJobOfferAsync(jobOffer);
                return CreatedAtAction(nameof(GetJobOfferById), new { id = createdJobOffer.JobListingId }, createdJobOffer);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobListing>> GetJobOfferById(int id)
        {
            var jobOffer = await _jobOfferService.GetJobOfferByIdAsync(id);
            if (jobOffer == null) return NotFound();
            return Ok(jobOffer);
        }

        // Additional endpoints can be added as needed
    }
}
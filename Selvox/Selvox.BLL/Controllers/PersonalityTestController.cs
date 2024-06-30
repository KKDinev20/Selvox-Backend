using System.Security.Claims;
using Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Selvox.BLL.DTOs;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.Controllers
{
    [Route("api/[controller]")]
    [EnableCors()]
    [ApiController]
    public class PersonalityTestController : ControllerBase
    {
        private readonly IPersonalityAssessmentService _personalityAssessmentService;

        public PersonalityTestController(IPersonalityAssessmentService personalityAssessmentService)
        {
            _personalityAssessmentService = personalityAssessmentService;
        }

        [HttpPost("submit")]
        [Authorize(Roles = "jobseeker")]
        public async Task<IActionResult> SubmitAssessment([FromBody] PersonalityAssessmentDTO assessmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { message = "User not found." });
            }

            assessmentDto.UserId = int.Parse(userId);

            var result = await _personalityAssessmentService.SubmitAssessmentAsync(assessmentDto);
            return Ok(result);
        }
    }
}

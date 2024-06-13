using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Selvox.BLL.Data_Objects;
using Selvox.BLL.Services;
using Selvox.DAL.Models;

namespace Selvox.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssessmentController : ControllerBase
{
    private readonly AssessmentService _assessmentService;

    public AssessmentController(AssessmentService assessmentService)
    {
        _assessmentService = assessmentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAssessment([FromBody] AssessmentCreateDto assessmentCreateDto)
    {
        var assessment = await _assessmentService.CreateAssessment
        (
            assessmentCreateDto.UserId,
            assessmentCreateDto.PersonalityTraits,
            assessmentCreateDto.Skills,
            assessmentCreateDto.Interests
        );
        return CreatedAtAction(nameof(GetAssessment), new { id = assessment.AssessmentID }, assessment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAssessment(int id)
    {
        var assessment = await _assessmentService.GetAssessmentById(id);
        if (assessment == null)
        {
            return NotFound();
        }
        return Ok(assessment);
    }
    
}


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
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAssessmentByUserId(int userId)
    {
        var assessment = await _assessmentService.GetAssessmentByUserId(userId);
        return Ok(assessment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAssessment(int id, [FromBody] AssessmentUpdateDto assessmentUpdateDto)
    {
        try
        {
            var assessment = _assessmentService.UpdateAssessment
            (
                id,
                assessmentUpdateDto.PersonalityTraits,
                assessmentUpdateDto.Skills,
                assessmentUpdateDto.Interests
            );
            return Ok(assessment);
        }
        catch(Exception ex)
        {
            return BadRequest(new {message = ex.Message});
        }
    }

    /*[HttpGet("{id}/analysis")]
    public async Task<IActionResult> AnalyzeAssessment(int id)
    {
        
    }*/
}


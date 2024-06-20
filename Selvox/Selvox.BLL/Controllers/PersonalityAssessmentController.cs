using Microsoft.AspNetCore.Mvc;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selvox.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalityAssessmentsController : ControllerBase
    {
        private readonly IPersonalityAssessmentRepository _service;

        public PersonalityAssessmentsController(IPersonalityAssessmentRepository service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalityAssessment>>> GetAllAssessmentsAsync()
        {
            var assessments = await _service.GetAllAssessmentsAsync();
            if (assessments == null)
            {
                return NotFound();
            }

            return Ok(assessments);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalityAssessment>> GetAssessmentByIdAsync(int id)
        {
            var assessment = await _service.GetAssessmentByIdAsync(id);

            if (assessment == null)
            {
                return NotFound();
            }

            return assessment;
        }
        
        [HttpPost]
        public async Task<ActionResult<PersonalityAssessment>> PostAssessmentAsync([FromBody] PersonalityAssessment assessment)
        {
            var result = await _service.AddAssessmentAsync(assessment);
            return CreatedAtAction(nameof(GetAssessmentByIdAsync), new { id = result.AssessmentId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessmentAsync(int id, [FromBody] PersonalityAssessment assessment)
        {
            if (id!= assessment.AssessmentId)
            {
                return BadRequest();
            }

            var result = await _service.UpdateAssessmentAsync(assessment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssessmentAsync(int id)
        {
            var success = await _service.DeleteAssessmentAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

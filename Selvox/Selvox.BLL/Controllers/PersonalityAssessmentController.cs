using Microsoft.AspNetCore.Mvc;
using Selvox.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Selvox.BLL.DTOs;
using Selvox.DAL.Context;

namespace Selvox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalityAssessmentController : ControllerBase
    {
        private readonly SelvoxDbContext _context;

        public PersonalityAssessmentController(SelvoxDbContext context)
        {
            _context = context;
        }

        [HttpGet("questions")]
        public async Task<ActionResult<IEnumerable<PersonalityQuestion>>> GetQuestions()
        {
            var questions = await _context.PersonalityQuestions.ToListAsync();
            return Ok(questions);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAnswers([FromBody] List<PersonalityAnswerDTO> answers)
        {
            if (answers == null || !answers.Any())
            {
                return BadRequest(new { message = "Invalid answers" });
            }

            var userId = answers.First().UserId;

            var personalityAssessment = new PersonalityAssessment
            {
                UserId = userId,
                AssessmentDate = DateTimeOffset.UtcNow,
                Results = JsonSerializer.Serialize(answers),
                Summary = string.Empty,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            _context.PersonalityAssessments.Add(personalityAssessment);
            await _context.SaveChangesAsync();

            var jobFieldScores = new Dictionary<int, int>();

            foreach (var answer in answers)
            {
                var questionMappings = await _context.QuestionJobFieldMappings
                    .Where(q => q.QuestionId == answer.QuestionId)
                    .ToListAsync();

                foreach (var mapping in questionMappings)
                {
                    if (!jobFieldScores.ContainsKey(mapping.JobFieldId))
                    {
                        jobFieldScores[mapping.JobFieldId] = 0;
                    }
                    jobFieldScores[mapping.JobFieldId] += answer.Score;
                }
            }

            var results = jobFieldScores.Select(kvp => new PersonalityAssessmentResultDTO
            {
                JobFieldId = kvp.Key,
                MatchScore = kvp.Value / (answers.Count * 5.0m) * 100
            }).ToList();

            personalityAssessment.Summary = JsonSerializer.Serialize(results);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Answers submitted successfully", results });
        }

        [HttpGet("results/{userId}")]
        public async Task<ActionResult<IEnumerable<PersonalityAssessmentResultDTO>>> GetResults(int userId)
        {
            var assessment = await _context.PersonalityAssessments
                .Where(pa => pa.UserId == userId)
                .OrderByDescending(pa => pa.AssessmentDate)
                .FirstOrDefaultAsync();

            if (assessment == null)
            {
                return NotFound();
            }

            var results = JsonSerializer.Deserialize<List<PersonalityAssessmentResultDTO>>(assessment.Summary);
            return Ok(results);
        }
    }
}

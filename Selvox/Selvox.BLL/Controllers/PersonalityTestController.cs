using Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalityTestController : ControllerBase
    {
        private readonly SelvoxDbContext _context;

        public PersonalityTestController(SelvoxDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> SubmitAssessment([FromBody] AssessmentRequest request)
        {
            var assessment = new PersonalityAssessment
            {
                UserId = request.UserId,
                AssessmentDate = DateTimeOffset.UtcNow,
                Results = JsonConvert.Serialize(request.Answers),
                Summary = "Personality Assessment Results",
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            _context.PersonalityAssessments.Add(assessment);
            await _context.SaveChangesAsync();

            var jobFieldScores = CalculateJobFieldScores(request.Answers);

            var topJobFields = jobFieldScores
                .OrderByDescending(kvp => kvp.Value)
                .Take(3)
                .Select(kvp => kvp.Key)
                .ToList();

            var jobRecommendations = new List<CareerRecommendation>();

            foreach (var jobField in topJobFields)
            {
                var jobRole = _context.JobRoles.FirstOrDefault(jr => jr.Industry == jobField);
                if (jobRole != null)
                {
                    var recommendation = new CareerRecommendation
                    {
                        UserId = request.UserId,
                        JobRoleId = jobRole.JobRoleId,
                        RecommendationDate = DateTimeOffset.UtcNow,
                        MatchScore = jobFieldScores[jobField],
                        Comments = "Based on your assessment results.",
                        CreatedAt = DateTimeOffset.UtcNow,
                        UpdatedAt = DateTimeOffset.UtcNow
                    };

                    jobRecommendations.Add(recommendation);
                }
            }

            _context.CareerRecommendations.AddRange(jobRecommendations);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Recommendations = jobRecommendations.Select(jr => new
                {
                    JobRole = _context.JobRoles.FirstOrDefault(j => j.JobRoleId == jr.JobRoleId)?.Title,
                    MatchScore = jr.MatchScore
                })
            });
        }

        private Dictionary<string, decimal> CalculateJobFieldScores(int[] answers)
        {
            var jobFields = new List<string>
            {
                "Healthcare",
                "Art",
                "IT",
                "Education",
                "Engineering",
                "Business",
                "Law",
                "Science",
                "Social Services",
                "Media"
            };

            var scores = new Dictionary<string, decimal>();

            foreach (var jobField in jobFields)
            {
                scores[jobField] = 0;
            }

            // Example scoring logic, you can customize this based on your requirements
            for (int i = 0; i < answers.Length; i++)
            {
                if (i < 10) scores["Healthcare"] += answers[i];
                else if (i < 15) scores["Art"] += answers[i];
                else if (i < 20) scores["IT"] += answers[i];
                else if (i < 25) scores["Education"] += answers[i];
                else if (i < 30) scores["Engineering"] += answers[i];
                else if (i < 35) scores["Business"] += answers[i];
                else if (i < 40) scores["Law"] += answers[i];
                else if (i < 45) scores["Science"] += answers[i];
                else if (i < 50) scores["Social Services"] += answers[i];
                else if (i < 55) scores["Media"] += answers[i];
            }

            return scores;
        }
    }

    public class AssessmentRequest
    {
        public int UserId { get; set; }
        public int[] Answers { get; set; }
    }
}

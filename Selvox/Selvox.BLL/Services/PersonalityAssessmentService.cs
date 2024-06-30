using Json.Serialization;
using Selvox.BLL.DTOs;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories;

public class PersonalityAssessmentService : IPersonalityAssessmentService
{
    private readonly IPersonalityAssessmentRepository _assessmentRepository;
    private readonly SelvoxDbContext _context;

    public PersonalityAssessmentService(IPersonalityAssessmentRepository assessmentRepository, SelvoxDbContext context)
    {
        _assessmentRepository = assessmentRepository;
        _context = context;
    }


    public async Task<PersonalityAssessment> GetAssessmentByIdAsync(int id)
    {
        return await _assessmentRepository.GetAssessmentByIdAsync(id);
    }

    public async Task<IEnumerable<PersonalityAssessment>> GetAllAssessmentsAsync()
    {
        return await _assessmentRepository.GetAllAssessmentsAsync();
    }

    public async Task<PersonalityAssessment> AddAssessmentAsync(PersonalityAssessment assessment)
    {
        return await _assessmentRepository.AddAssessmentAsync(assessment);
    }

    public async Task<PersonalityAssessment> UpdateAssessmentAsync(PersonalityAssessment assessment)
    {
        return await _assessmentRepository.UpdateAssessmentAsync(assessment);
    }

    public async Task<bool> DeleteAssessmentAsync(int id)
    {
        return await _assessmentRepository.DeleteAssessmentAsync(id);
    }

    public async Task<AssessmentResultDTO> SubmitAssessmentAsync(PersonalityAssessmentDTO assessmentDto)
    {
        var user = await _context.Users.FindAsync(assessmentDto.UserId);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        var assessment = new PersonalityAssessment
        {
            UserId = assessmentDto.UserId,
            AssessmentDate = DateTimeOffset.UtcNow,
            Results = JsonConvert.Serialize(assessmentDto.Results),
            Summary = "Personality assessment results",
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };

        _context.PersonalityAssessments.Add(assessment);
        await _context.SaveChangesAsync();

        var result = new AssessmentResultDTO
        {
            RecommendedFields = GetRecommendedFields(assessmentDto.Results)
        };

        return result;
    }
    
    private List<string> GetRecommendedFields(Dictionary<string, int> results)
    {
        // Implement the logic to determine recommended fields based on assessment results.
        var recommendedFields = new List<string>();
        // Add logic here...
        return recommendedFields;
    }

}
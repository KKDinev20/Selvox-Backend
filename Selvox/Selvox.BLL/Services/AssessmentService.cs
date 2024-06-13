using Selvox.BLL.Repositories.Interfaces;
using Selvox.DAL.Models;

namespace Selvox.BLL.Services;

public class AssessmentService
{
    private readonly IAssessmentRepository _assessmentRepository;

    public AssessmentService(IAssessmentRepository assessmentRepository)
    {
        _assessmentRepository = assessmentRepository;
    }

    public async Task<Assessment> CreateAssessment(int id, string personalityTraits, string skills, string interests)
    {
        var assessment = new Assessment
        {
            UserID = id,
            PersonalityTraits = personalityTraits,
            Skills = skills,
            Interests = interests,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        return await _assessmentRepository.CreateAssessment(assessment);
    }

    public async Task<Assessment> GetAssessmentById(int assessmentId)
    {
        return await _assessmentRepository.GetAssessmentById(assessmentId);
    }

    public async Task<IEnumerable<Assessment>> GetAssessmentByUserId(int assessmentId)
    {
        return await _assessmentRepository.GetAssessmentByUserId(assessmentId);
    }

    public async Task<Assessment> UpdateAssessment(int id, string personalityTraits, string skills, string interests)
    {
        var assessment = await _assessmentRepository.GetAssessmentById(id);

        if (assessment == null)
        {
            throw new Exception("Assessment not found.");
        }

        assessment.PersonalityTraits = personalityTraits;
        assessment.Skills = skills;
        assessment.Interests = interests;
        assessment.UpdatedAt = DateTime.UtcNow;
        
        return await _assessmentRepository.UpdateAssessment(assessment);
    }

    public string AnalyzeAssessment(Assessment assessment)
    {
        return null;
    }
}
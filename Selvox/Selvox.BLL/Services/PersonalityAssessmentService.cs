using Selvox.BLL.Interfaces;
using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories;

public class PersonalityAssessmentService : IPersonalityAssessmentService
{
    private readonly IPersonalityAssessmentRepository _assessmentRepository;

    public PersonalityAssessmentService(IPersonalityAssessmentRepository assessmentRepository)
    {
        _assessmentRepository = assessmentRepository;
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
}
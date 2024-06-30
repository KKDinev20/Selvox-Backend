using Selvox.BLL.DTOs;
using Selvox.DAL.Models;

namespace Selvox.BLL.Interfaces;

public interface IPersonalityAssessmentService
{
    Task<PersonalityAssessment> GetAssessmentByIdAsync(int id);
    Task<IEnumerable<PersonalityAssessment>> GetAllAssessmentsAsync();
    Task<PersonalityAssessment> AddAssessmentAsync(PersonalityAssessment assessment);
    Task<PersonalityAssessment> UpdateAssessmentAsync(PersonalityAssessment assessment);
    Task<bool> DeleteAssessmentAsync(int id);
    Task<AssessmentResultDTO> SubmitAssessmentAsync(PersonalityAssessmentDTO assessmentDto);
}
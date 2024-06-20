using Selvox.DAL.Models;

namespace Selvox.BLL.Interfaces;

public interface IPersonalityAssessmentRepository
{
    Task<PersonalityAssessment> GetAssessmentByIdAsync(int id);
    Task<IEnumerable<PersonalityAssessment>> GetAllAssessmentsAsync();
    Task<PersonalityAssessment> AddAssessmentAsync(PersonalityAssessment assessment);
    Task<PersonalityAssessment> UpdateAssessmentAsync(PersonalityAssessment assessment);
    Task<bool> DeleteAssessmentAsync(int id); //delete visually, but not from the database
}
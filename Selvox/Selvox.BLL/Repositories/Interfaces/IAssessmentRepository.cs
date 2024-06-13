using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories.Interfaces;

public interface IAssessmentRepository
{
    Task<Assessment> CreateAssessment(Assessment assessment);
    Task<Assessment> GetAssessmentById(int id);
    Task<IEnumerable<Assessment>> GetAssessmentByUserId(int userId);
    Task<Assessment> UpdateAssessment(Assessment assessment);
}
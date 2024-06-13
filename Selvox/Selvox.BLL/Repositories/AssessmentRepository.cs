using Microsoft.EntityFrameworkCore;
using Selvox.BLL.Repositories.Interfaces;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories;

public class AssessmentRepository : IAssessmentRepository
{
    private readonly SelvoxDbContext _selvoxDbContext;

    public AssessmentRepository(SelvoxDbContext selvoxDbContext)
    {
        _selvoxDbContext = selvoxDbContext;
    }

    public async Task<Assessment> CreateAssessment(Assessment assessment)
    {
        _selvoxDbContext.Assessments.AddAsync(assessment);

        await _selvoxDbContext.SaveChangesAsync();

        return assessment;
    }

    public async Task<Assessment> GetAssessmentById(int id)
    {
        return await _selvoxDbContext.Assessments.FindAsync(id);
    }

    public async Task<IEnumerable<Assessment>> GetAssessmentByUserId(int userId)
    {
        return await _selvoxDbContext.Assessments.Where(x => x.UserID == userId).ToListAsync();
    }

    public async Task<Assessment> UpdateAssessment(Assessment assessment)
    {
        _selvoxDbContext.Assessments.Update(assessment);
        await _selvoxDbContext.SaveChangesAsync();
        return assessment;
    }
}
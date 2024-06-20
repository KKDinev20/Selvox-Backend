using Microsoft.EntityFrameworkCore;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories;

public class PersonalityAssessmentRepository : IPersonalityAssessmentRepository
{
    private readonly SelvoxDbContext _selvoxDbContext;

    public PersonalityAssessmentRepository(SelvoxDbContext selvoxDbContext)
    {
        _selvoxDbContext = selvoxDbContext;
    }

    public async Task<PersonalityAssessment> GetAssessmentByIdAsync(int id)
    {
        return await _selvoxDbContext.PersonalityAssessments.FindAsync(id);
    }

    public async Task<IEnumerable<PersonalityAssessment>> GetAllAssessmentsAsync()
    {
        return await _selvoxDbContext.PersonalityAssessments.ToListAsync();
    }

    public async Task<PersonalityAssessment> AddAssessmentAsync(PersonalityAssessment assessment)
    {
        _selvoxDbContext.PersonalityAssessments.AddAsync(assessment);
        await _selvoxDbContext.SaveChangesAsync();
        return assessment;
    }

    public async Task<PersonalityAssessment> UpdateAssessmentAsync(PersonalityAssessment assessment)
    {
        _selvoxDbContext.Entry(assessment).State = EntityState.Modified;
        await _selvoxDbContext.SaveChangesAsync();
        return assessment;
    }

    public async Task<bool> DeleteAssessmentAsync(int id)
    {
        var assessment  = await _selvoxDbContext.Users.FindAsync(id);
        if (assessment  == null)
            return false;

        _selvoxDbContext.Users.Remove(assessment);
        await _selvoxDbContext.SaveChangesAsync();
        return true;
    }
}
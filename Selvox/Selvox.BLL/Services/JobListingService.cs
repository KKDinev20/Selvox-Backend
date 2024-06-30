using Microsoft.EntityFrameworkCore;
using Selvox.BLL.DTOs;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories;

public class JobListingService : IJobListingService
{
    private readonly SelvoxDbContext _selvoxDbContext;

    public JobListingService(SelvoxDbContext selvoxDbContext)
    {
        _selvoxDbContext = selvoxDbContext;
    }

    public async Task AddJobListingAsync(JobListingDTO jobListingDto)
    {
        var employer = await _selvoxDbContext.Employers.FindAsync(jobListingDto.EmployerId);
        var jobRole = await _selvoxDbContext.JobRoles.FindAsync(jobListingDto.JobRoleId);

        if (employer == null)
        {
            throw new Exception("Employer not found.");
        }

        if (jobRole == null)
        {
            throw new Exception("Job role not found.");
        }

        var jobListing = new JobListing
        {
            EmployerId = employer.EmployerId,
            JobRoleId = jobRole.JobRoleId,
            JobTitle = jobListingDto.JobTitle,
            JobDescription = jobListingDto.JobDescription,
            Location = jobListingDto.Location,
            SalaryRange = jobListingDto.SalaryRange,
            PostedDate = jobListingDto.PostedDate,
            ExpirationDate = jobListingDto.ExpirationDate,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };

        _selvoxDbContext.JobListings.Add(jobListing);
        await _selvoxDbContext.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<JobListing>> GetAllJobListingsAsync()
    {
        return await _selvoxDbContext.JobListings.ToListAsync();
    }
    

}
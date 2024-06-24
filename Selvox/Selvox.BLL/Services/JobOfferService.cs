using Microsoft.EntityFrameworkCore;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories;

public class JobOfferService : IJobOfferService
{
    private readonly SelvoxDbContext _context;

    public JobOfferService(SelvoxDbContext context)
    {
        _context = context;
    }


    public async Task<JobListing> CreateJobOfferAsync(JobListing jobListing)
    {
        _context.JobListings.Add(jobListing);
        await _context.SaveChangesAsync();
        return jobListing;
    }

    public async Task<JobListing> GetJobOfferByIdAsync(int id)
    {
        return await _context.JobListings.FindAsync(id);
    }

    public async  Task<IEnumerable<JobListing>> GetAllJobOffersAsync()
    {
        return await _context.JobListings.ToListAsync();
    }

    public async Task<JobListing> UpdateJobOfferAsync(JobListing jobListing)
    {
        _context.Entry(jobListing).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return jobListing;
    }

    public async Task<bool> DeleteJobOfferAsync(int id)
    {
        var jobListing = await _context.JobListings.FindAsync(id);
        if (jobListing == null) return false;

        _context.JobListings.Remove(jobListing);
        await _context.SaveChangesAsync();
        return true;
    }
}
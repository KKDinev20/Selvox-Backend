using Selvox.BLL.DTOs;
using Selvox.DAL.Models;

namespace Selvox.BLL.Interfaces;

public interface IJobListingService
{
    Task AddJobListingAsync(JobListingDTO jobListing);
    Task<IEnumerable<JobListing>> GetAllJobListingsAsync();
    Task<JobListing> GetJobListingByIDAsync(int id);
    Task DeleteJobListingAsync(int id);
    Task UpdateJobListingAsync(int id, JobListingDTO jobListingDto);
}
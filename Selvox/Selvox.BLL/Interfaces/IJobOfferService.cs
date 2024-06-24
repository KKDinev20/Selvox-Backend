using Selvox.DAL.Models;

namespace Selvox.BLL.Interfaces;

public interface IJobOfferService
{
    Task<JobListing> CreateJobOfferAsync(JobListing jobListing);
    Task<JobListing> GetJobOfferByIdAsync(int id);
    Task<IEnumerable<JobListing>> GetAllJobOffersAsync();
    Task<JobListing> UpdateJobOfferAsync(JobListing jobListing);
    Task<bool> DeleteJobOfferAsync(int id);
}
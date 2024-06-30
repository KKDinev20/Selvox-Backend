using Selvox.BLL.DTOs;
using Selvox.DAL.Models;

namespace Selvox.BLL.Interfaces;

public interface IJobListingService
{
    Task AddJobListingAsync(JobListingDTO jobListing);
}
namespace Selvox.BLL.DTOs;

public class JobListingDTO
{
    public int JobListingId { get; set; }

    public int? EmployerId { get; set; }

    public int? JobRoleId { get; set; }

    public string JobTitle { get; set; } = null!;

    public string? JobDescription { get; set; }

    public string? Location { get; set; }

    public decimal? SalaryRange { get; set; }

    public DateTimeOffset PostedDate { get; set; }

    public DateTimeOffset ExpirationDate { get; set; }
}
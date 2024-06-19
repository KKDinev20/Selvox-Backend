using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class JobListing
{
    [Key]
    public int JobListingId { get; set; }

    public int? EmployerId { get; set; }

    public int? JobRoleId { get; set; }

    [StringLength(100)]
    public string JobTitle { get; set; } = null!;

    public string? JobDescription { get; set; }

    [StringLength(100)]
    public string? Location { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SalaryRange { get; set; }

    public DateTimeOffset PostedDate { get; set; }

    public DateTimeOffset ExpirationDate { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    [InverseProperty("JobListing")]
    public virtual ICollection<Application> Applications { get; } = new List<Application>();

    [ForeignKey("EmployerId")]
    [InverseProperty("JobListings")]
    public virtual Employer? Employer { get; set; }

    [ForeignKey("JobRoleId")]
    [InverseProperty("JobListings")]
    public virtual JobRole? JobRole { get; set; }
}

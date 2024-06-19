using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Employer
{
    [Key]
    public int EmployerId { get; set; }

    [StringLength(100)]
    public string CompanyName { get; set; } = null!;

    public int? IndustryId { get; set; }

    public string? CompanyDescription { get; set; }

    [StringLength(255)]
    public string? Website { get; set; }

    [StringLength(255)]
    public string? ContactEmail { get; set; }

    [StringLength(15)]
    public string? ContactPhone { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    [ForeignKey("IndustryId")]
    [InverseProperty("Employers")]
    public virtual Industry? Industry { get; set; }

    [InverseProperty("Employer")]
    public virtual ICollection<JobListing> JobListings { get; } = new List<JobListing>();
}

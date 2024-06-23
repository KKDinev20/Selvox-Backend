using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class JobRole
{
    [Key]
    public int JobRoleId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(50)]
    public string Industry { get; set; } = null!;

    public string? RequiredSkills { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SalaryRange { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    [InverseProperty("JobRole")]
    public virtual ICollection<CareerRecommendation> CareerRecommendations { get; } = new List<CareerRecommendation>();

    [InverseProperty("JobRole")]
    public virtual ICollection<JobListing> JobListings { get; } = new List<JobListing>();

    [InverseProperty("JobField")]
    public virtual ICollection<QuestionJobFieldMapping> QuestionJobFieldMappings { get; } = new List<QuestionJobFieldMapping>();
}

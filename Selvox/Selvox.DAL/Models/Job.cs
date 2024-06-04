using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Job
{
    [Key]
    public int JobId { get; set; }

    [StringLength(100)]
    public string JobTitle { get; set; } = null!;

    [StringLength(100)]
    public string? Industry { get; set; }

    public string? Description { get; set; }

    public string? RequiredSkills { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<JobMatch> JobMatches { get; } = new List<JobMatch>();
}

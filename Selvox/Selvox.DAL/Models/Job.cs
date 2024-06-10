using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Job
{
    [Key]
    public int JobID { get; set; }

    [StringLength(255)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Requirements { get; set; }

    [StringLength(100)]
    public string? Location { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SalaryRange { get; set; }

    public int? PostedByUserID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PostedAt { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<EmployerJob> EmployerJobs { get; } = new List<EmployerJob>();

    [InverseProperty("Job")]
    public virtual ICollection<Interview> Interviews { get; } = new List<Interview>();

    [ForeignKey("PostedByUserID")]
    [InverseProperty("Jobs")]
    public virtual User? PostedByUser { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<UserJob> UserJobs { get; } = new List<UserJob>();
}

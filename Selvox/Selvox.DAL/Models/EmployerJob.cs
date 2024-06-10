using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[PrimaryKey("EmployerID", "JobID")]
public partial class EmployerJob
{
    [Key]
    public int EmployerID { get; set; }

    [Key]
    public int JobID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PostedAt { get; set; }

    [ForeignKey("EmployerID")]
    [InverseProperty("EmployerJobs")]
    public virtual Employer Employer { get; set; } = null!;

    [ForeignKey("JobID")]
    [InverseProperty("EmployerJobs")]
    public virtual Job Job { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[PrimaryKey("UserID", "JobID")]
public partial class UserJob
{
    [Key]
    public int UserID { get; set; }

    [Key]
    public int JobID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AppliedAt { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [ForeignKey("JobID")]
    [InverseProperty("UserJobs")]
    public virtual Job Job { get; set; } = null!;

    [ForeignKey("UserID")]
    [InverseProperty("UserJobs")]
    public virtual User User { get; set; } = null!;
}

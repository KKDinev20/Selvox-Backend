using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Interview
{
    [Key]
    public int InterviewID { get; set; }

    public int? UserID { get; set; }

    public int? JobID { get; set; }

    public int? EmployerID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InterviewDate { get; set; }

    public TimeSpan? InterviewTime { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("EmployerID")]
    [InverseProperty("Interviews")]
    public virtual Employer? Employer { get; set; }

    [InverseProperty("Interview")]
    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    [ForeignKey("JobID")]
    [InverseProperty("Interviews")]
    public virtual Job? Job { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("Interviews")]
    public virtual User? User { get; set; }
}

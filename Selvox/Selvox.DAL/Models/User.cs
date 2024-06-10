using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Index("Username", Name = "UQ__Users__536C85E49F61FBB1", IsUnique = true)]
[Index("Email", Name = "UQ__Users__A9D10534AB2A0C17", IsUnique = true)]
public partial class User
{
    [Key]
    public int UserID { get; set; }

    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    [StringLength(50)]
    public string? Role { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Assessment> Assessments { get; } = new List<Assessment>();

    [InverseProperty("User")]
    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    [InverseProperty("User")]
    public virtual ICollection<Interview> Interviews { get; } = new List<Interview>();

    [InverseProperty("PostedByUser")]
    public virtual ICollection<Job> Jobs { get; } = new List<Job>();

    [InverseProperty("User")]
    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    [InverseProperty("User")]
    public virtual ICollection<UserJob> UserJobs { get; } = new List<UserJob>();
}

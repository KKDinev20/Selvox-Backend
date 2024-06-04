using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<JobMatch> JobMatches { get; } = new List<JobMatch>();

    [InverseProperty("User")]
    public virtual Role? Role { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<TestResult> TestResults { get; } = new List<TestResult>();

    [InverseProperty("User")]
    public virtual ICollection<UserProfile> UserProfiles { get; } = new List<UserProfile>();
}

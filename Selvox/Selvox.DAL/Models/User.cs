using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Index("Email", Name = "UQ__Users__A9D1053445F43A0E", IsUnique = true)]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    [StringLength(20)]
    public string Role { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Gender { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Application> Applications { get; } = new List<Application>();

    [InverseProperty("User")]
    public virtual ICollection<CareerRecommendation> CareerRecommendations { get; } = new List<CareerRecommendation>();

    [InverseProperty("User")]
    public virtual ICollection<PersonalityAssessment> PersonalityAssessments { get; } = new List<PersonalityAssessment>();

    [InverseProperty("User")]
    public virtual ICollection<UserSkill> UserSkills { get; } = new List<UserSkill>();
}

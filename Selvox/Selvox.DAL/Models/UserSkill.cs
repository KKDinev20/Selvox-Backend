using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class UserSkill
{
    [Key]
    public int UserSkillId { get; set; }

    public int? UserId { get; set; }

    public int? SkillId { get; set; }

    [StringLength(20)]
    public string ProficiencyLevel { get; set; } = null!;

    public DateTimeOffset AcquiredDate { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    [ForeignKey("SkillId")]
    [InverseProperty("UserSkills")]
    public virtual Skill? Skill { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserSkills")]
    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Skill
{
    [Key]
    public int SkillId { get; set; }

    [StringLength(50)]
    public string SkillName { get; set; } = null!;

    public string? Description { get; set; }

    [InverseProperty("Skill")]
    public virtual ICollection<UserSkill> UserSkills { get; } = new List<UserSkill>();
}

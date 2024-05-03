using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Keyless]
public partial class Users_Skill
{
    public int? UserID { get; set; }

    public int? SkillID { get; set; }

    [ForeignKey("SkillID")]
    public virtual Skill? Skill { get; set; }

    [ForeignKey("UserID")]
    public virtual User? User { get; set; }
}

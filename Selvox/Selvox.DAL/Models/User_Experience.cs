using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Keyless]
[Table("User_Experience")]
public partial class User_Experience
{
    public int? UserID { get; set; }

    public int? ExperienceID { get; set; }

    [ForeignKey("ExperienceID")]
    public virtual Experience? Experience { get; set; }

    [ForeignKey("UserID")]
    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Keyless]
[Table("User_Education")]
public partial class User_Education
{
    public int? UserID { get; set; }

    public int? EducationID { get; set; }

    [ForeignKey("EducationID")]
    public virtual Education? Education { get; set; }

    [ForeignKey("UserID")]
    public virtual User? User { get; set; }
}

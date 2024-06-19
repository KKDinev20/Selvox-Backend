using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Industry
{
    [Key]
    public int IndustryId { get; set; }

    [StringLength(50)]
    public string IndustryName { get; set; } = null!;

    public string? Description { get; set; }

    [InverseProperty("Industry")]
    public virtual ICollection<Employer> Employers { get; } = new List<Employer>();
}

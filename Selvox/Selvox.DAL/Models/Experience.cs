using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Table("Experience")]
public partial class Experience
{
    [Key]
    public int Id { get; set; }

    public int? UserID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Company { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Position { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }
}

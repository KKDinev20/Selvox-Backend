using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Table("Education")]
public partial class Education
{
    [Key]
    public int Id { get; set; }

    public int? UserID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Institution { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Degree { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Major { get; set; }

    [Column(TypeName = "date")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }
}

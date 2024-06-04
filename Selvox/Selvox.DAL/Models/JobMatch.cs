using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class JobMatch
{
    [Key]
    public int MatchId { get; set; }

    public int UserId { get; set; }

    public int JobId { get; set; }

    public double? MatchScore { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("JobId")]
    [InverseProperty("JobMatches")]
    public virtual Job Job { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("JobMatches")]
    public virtual User User { get; set; } = null!;
}

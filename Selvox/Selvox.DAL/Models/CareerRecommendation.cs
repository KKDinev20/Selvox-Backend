using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class CareerRecommendation
{
    [Key]
    public int RecommendationId { get; set; }

    public int? UserId { get; set; }

    public int? JobRoleId { get; set; }

    public DateTimeOffset RecommendationDate { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? MatchScore { get; set; }

    public string? Comments { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    [ForeignKey("JobRoleId")]
    [InverseProperty("CareerRecommendations")]
    public virtual JobRole? JobRole { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("CareerRecommendations")]
    public virtual User? User { get; set; }
}

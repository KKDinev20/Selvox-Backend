using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class PersonalityAssessment
{
    [Key]
    public int AssessmentId { get; set; }

    public int? UserId { get; set; }

    public DateTimeOffset AssessmentDate { get; set; }

    public string? Results { get; set; }

    public string? Summary { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("PersonalityAssessments")]
    public virtual User? User { get; set; }
}

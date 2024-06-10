﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Assessment
{
    [Key]
    public int AssessmentID { get; set; }

    public int? UserID { get; set; }

    public string? PersonalityTraits { get; set; }

    public string? Skills { get; set; }

    public string? Interests { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("Assessments")]
    public virtual User? User { get; set; }
}

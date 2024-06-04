using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class PersonalityTest
{
    [Key]
    public int TestId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string? Options { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Test")]
    public virtual ICollection<TestResult> TestResults { get; } = new List<TestResult>();
}

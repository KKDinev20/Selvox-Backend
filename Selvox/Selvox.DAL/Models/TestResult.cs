using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class TestResult
{
    [Key]
    public int ResultId { get; set; }

    public int UserId { get; set; }

    public int TestId { get; set; }

    public string? Answer { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("TestId")]
    [InverseProperty("TestResults")]
    public virtual PersonalityTest Test { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("TestResults")]
    public virtual User User { get; set; } = null!;
}

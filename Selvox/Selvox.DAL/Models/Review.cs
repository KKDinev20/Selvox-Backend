using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Review
{
    [Key]
    public int Id { get; set; }

    public int? ReviewerID { get; set; }

    public int? JobID { get; set; }

    public int? Rating { get; set; }

    [Column(TypeName = "text")]
    public string? Comment { get; set; }

    [ForeignKey("JobID")]
    [InverseProperty("Reviews")]
    public virtual Job? Job { get; set; }

    [ForeignKey("ReviewerID")]
    [InverseProperty("Reviews")]
    public virtual User? Reviewer { get; set; }
}

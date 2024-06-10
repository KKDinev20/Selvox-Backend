using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Table("Feedback")]
public partial class Feedback
{
    [Key]
    public int FeedbackID { get; set; }

    public int? UserID { get; set; }

    public int? InterviewID { get; set; }

    public int? Rating { get; set; }

    public string? Comments { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? GivenAt { get; set; }

    [ForeignKey("InterviewID")]
    [InverseProperty("Feedbacks")]
    public virtual Interview? Interview { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("Feedbacks")]
    public virtual User? User { get; set; }
}

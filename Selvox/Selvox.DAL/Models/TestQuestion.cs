using System.ComponentModel.DataAnnotations;

namespace Selvox.DAL.Models;

public class TestQuestion
{
    [Key]
    public int QuestionId { get; set; }

    [Required]
    [StringLength(255)]
    public string QuestionText { get; set; }

    [StringLength(50)]
    public string Category { get; set; }
}
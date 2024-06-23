using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selvox.DAL.Models;

public class PersonalityTestAnswer
{
    [Key]
    public int AnswerId { get; set; }
    public int QuestionId { get; set; }
    public string AnswerText { get; set; }
    public int Score { get; set; }
    public string JobField { get; set; }  // E.g., Healthcare, Art, IT, etc.

    [ForeignKey("QuestionId")]
    public PersonalityTestQuestion Question { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Selvox.DAL.Models;

public class PersonalityTestQuestion
{
    [Key]
    public int QuestionId { get; set; }
    public string QuestionText { get; set; }
    public List<PersonalityTestAnswer> Answers { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selvox.DAL.Models;

public class UserTestResponse
{
    [Key]
    public int ResponseId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int QuestionId { get; set; }

    [Required]
    public int Answer { get; set; }  
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("QuestionId")]
    public virtual TestQuestion TestQuestion { get; set; }
}
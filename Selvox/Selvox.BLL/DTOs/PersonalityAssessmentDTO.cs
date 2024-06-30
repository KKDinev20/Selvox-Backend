namespace Selvox.BLL.DTOs;

public class PersonalityAssessmentDTO
{
    public int UserId { get; set; }
    public Dictionary<string, int> Results { get; set; }
    
}
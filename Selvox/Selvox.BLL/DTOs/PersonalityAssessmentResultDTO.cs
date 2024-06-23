namespace Selvox.BLL.DTOs;

public class PersonalityAssessmentResultDTO
{
    public int AssessmentId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset AssessmentDate { get; set; }
    public string Results { get; set; }
    public string Summary { get; set; }
    public int JobFieldId { get; set; }
    public decimal MatchScore { get; set; }
}
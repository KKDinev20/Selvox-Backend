namespace Selvox.DAL.Models;

public class CareerRecommendation
{
    public int Id { get; set; }
    
    public string JobTitle { get; set; }
    public string Industry { get; set; }
    public string Description { get; set; }
    
    public User User { get; set; }
}
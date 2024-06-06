namespace Selvox.DAL.Models;

public class User
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public List<Skill> Skills = new List<Skill>();
    public List<Interest> Interests = new List<Interest>();
    public List<CareerRecommendation> CareerRecommendations = new List<CareerRecommendation>();
}
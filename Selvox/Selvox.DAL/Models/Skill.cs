namespace Selvox.DAL.Models;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public User User { get; set; }

}
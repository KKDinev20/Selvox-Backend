namespace Selvox.DAL.Models;

public class Assessment
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    public User User { get; set; }
}
namespace Selvox.BLL.DTOs;

public class UserUpdateDTO
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    public string? PasswordHash { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public string Gender { get; set; }
}
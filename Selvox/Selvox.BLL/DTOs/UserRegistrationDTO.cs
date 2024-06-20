using System.ComponentModel.DataAnnotations;

namespace Selvox.BLL.DTOs;

public class UserRegistrationDTO
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string PasswordHash { get; set; } = null!;
    
    public string Role { get; set; }
}
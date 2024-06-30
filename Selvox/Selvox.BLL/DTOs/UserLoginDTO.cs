using System.ComponentModel.DataAnnotations;

namespace Selvox.BLL.DTOs;

public class UserLoginDTO
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string PasswordHash { get; set; }
}
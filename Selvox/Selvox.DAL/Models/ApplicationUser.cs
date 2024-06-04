using Microsoft.AspNetCore.Identity;

namespace Selvox.DAL.Models;

public class ApplicationUser : IdentityUser
{
    public virtual UserProfile UserProfile { get; set; }
}
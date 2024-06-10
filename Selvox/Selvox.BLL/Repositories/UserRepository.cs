using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Selvox.BLL.Repositories.Interfaces;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SelvoxDbContext _selvoxDbContext;

    public UserRepository(SelvoxDbContext selvoxDbContext)
    {
        _selvoxDbContext = selvoxDbContext;
    }

    public async Task<User> Register(string username, string email, string password, string role)
    {
        if (await _selvoxDbContext.Users.AnyAsync(u => u.Username == username || u.Email == email))
        {
            throw new Exception("User already exists.");
        }

        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = HashPassword(password),
            Role = role,
            CreatedAt = DateTime.UtcNow
        };

        _selvoxDbContext.Users.Add(user);
        await _selvoxDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> Authenticate(string username, string password)
    {
        var user = await _selvoxDbContext.Users.SingleOrDefaultAsync(u => u.Username == username);

        if (user == null || VerifyPassword(password, user.PasswordHash))
        {
            throw new InvalidCredentialException("Invalid Login attempt.");
        }

        return user;
    }

    
    private string HashPassword(string password)
    {
        using SHA256 sha256 = SHA256.Create();

        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

        return Convert.ToBase64String(hashedBytes);
    }

 
    private bool VerifyPassword(string password, string userPasswordHash)
    {
        var hasOutput = HashPassword(password);

        return hasOutput == userPasswordHash;
    }
}
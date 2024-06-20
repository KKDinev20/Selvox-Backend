using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Selvox.BLL.Interfaces;
using Selvox.DAL.Context;
using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<User> AddUserAsync(User user)
    {
        return await _userRepository.AddUserAsync(user);
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        return await _userRepository.UpdateUserAsync(user);
    }

    public async Task<User> AuthenticateUserAsync(string email, string password)
    {
        var user = await _userRepository.GetUsersByEmailAsync(email);

        if (user == null || user.PasswordHash != password)
        {
            return null;
        }

        return user;
    }

    public async Task<User> RegisterUserAsync(User user, string password)
    {
        var existingUser = await _userRepository.GetUsersByEmailAsync(user.Email);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists.");
        }

        user.PasswordHash = HashPassword(password);
        user.CreatedAt = DateTimeOffset.UtcNow;
        user.UpdatedAt = DateTimeOffset.UtcNow;

        return await _userRepository.AddUserAsync(user);
    }

    private string HashPassword(string password)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return hashed;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
}
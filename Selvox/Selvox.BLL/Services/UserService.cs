using Microsoft.Extensions.Caching.Memory;
using Selvox.BLL.Repositories.Interfaces;
using Selvox.DAL.Models;

namespace Selvox.BLL.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMemoryCache _cache;

    public UserService(IUserRepository userRepository, IMemoryCache memoryCache)
    {
        _userRepository = userRepository;
        _cache = memoryCache;
    }

    public Task<User> Authenticate(string username, string password)
    {
        return _userRepository.Authenticate(username, password);
    }
    
    public Task<User> Register(string username, string email, string password, string role)
    {
        if (!new[] { "jobseeker", "employer", "admin" }.Contains(role.ToLower()))
        {
            throw new ArgumentException("Invalid User role.");
        }
        return _userRepository.Register(username, email, password, role);
    }
    
    public void Logout(string sessionId)
    {
        _cache.Remove(sessionId);
    }

    public async Task<string> Login(string username, string password)
    {
        var user = await Authenticate(username, password);

        var sessionId = Guid.NewGuid().ToString();
        
        _cache.Set(sessionId, user, TimeSpan.FromHours(1));

        return sessionId;
    }
    
    public User GetUserBySessionId(string sessionId)
    {
        _cache.TryGetValue(sessionId, out User user);
        return user;
    }

    public bool HasRole(string sessionId, string role)
    {
        var user = GetUserBySessionId(sessionId);
        return user != null && user.Role?.Equals(role, StringComparison.OrdinalIgnoreCase) == true;
    }
}
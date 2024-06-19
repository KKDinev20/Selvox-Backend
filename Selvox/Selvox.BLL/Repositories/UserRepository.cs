using Microsoft.EntityFrameworkCore;
using Selvox.BLL.Interfaces;
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

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _selvoxDbContext.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _selvoxDbContext.Users.ToListAsync();
    }

    public async Task<User> AddUserAsync(User user)
    {
        _selvoxDbContext.Users.AddAsync(user);
        await _selvoxDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _selvoxDbContext.Entry(user).State = EntityState.Modified;
        await _selvoxDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _selvoxDbContext.Users.FindAsync(id);
        if (user == null)
            return false;

        _selvoxDbContext.Users.Remove(user);
        await _selvoxDbContext.SaveChangesAsync();
        return true;
    }
}
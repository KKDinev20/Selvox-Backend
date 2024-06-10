using Selvox.DAL.Models;

namespace Selvox.BLL.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> Register(string username, string email, string password, string role);
    Task<User> Authenticate(string username, string password);
}
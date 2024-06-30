using Selvox.DAL.Models;

namespace Selvox.BLL.Interfaces;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> AddUserAsync(User user);
    Task<User> UpdateUserAsync(User user);

    Task<User> AuthenticateUserAsync(string email, string password);
    Task<User> RegisterUserAsync(User user, string password);
    
    Task<bool> DeleteUserAsync(int id); 
    Task<Employer> GetEmployerByIdAsync(int employerId);

}
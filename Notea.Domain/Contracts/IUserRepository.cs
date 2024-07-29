using Notea.Domain.Models;

namespace Notea.Domain.Contracts;

/// <summary>
///     IUserRepository for interacting with the UserService.
/// </summary>
public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(string userId);
    Task<User> PostUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);    
}

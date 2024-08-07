using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Notea.Domain.Context;
using Notea.Domain.Models.User;
using Notea.Domain.User.Models.Responses;

namespace Notea.Domain.User;

public class UserService
{
    private readonly ApplicationDbContext _context;

    private static Expression<Func<ApplicationUser, UserResponse>> MapUserToDto = user => new UserResponse
    {
        Id = user.Id,
        UserName = user.UserName,
        Email = user.Email,
        FirstName = user.FirstName,
        LastName = user.LastName,
        FullName = user.FullName,
        CreatedAt = user.CreatedAt,
        LastLogin = user.LastLogin
    };

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<UserResponse>> GetUsersAsync()
    {
        try
        {
            var users = await _context.Users
                .OrderBy(user => user.Id)
                .Select(MapUserToDto)
                .ToListAsync();

            return users;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");

            return new List<UserResponse>();
        }
    }

    public async Task<UserResponse?> GetUserByIdAsync(string userId)
    {
        try
        {
            var user = await GetUser(userId);

            if (user == null)
            {
                Console.WriteLine($"User with ID {userId} not found.");
                return null;
            }

            return new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                CreatedAt = user.CreatedAt,
                LastLogin = user.LastLogin
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving the user: {ex.Message}");

            return null;
        }
    }

    public async Task DeleteUserAsync(string userId)
    {
        try
        {
            var user = await GetUser(userId);

            if (user == null)
            {
                Console.WriteLine($"User with ID {userId} not found.");
                return;
            }

            await _context.Users.Where(u => u.Id == user.Id).ExecuteDeleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");

            throw;
        }
    }

    private async Task<ApplicationUser?> GetUser(string userId)
    {
        try
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving the user with ID {userId}: {ex.Message}");
            return null;
        }
    }

}
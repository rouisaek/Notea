using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Notea.Domain.Context;
using Notea.Domain.Models.Users;
using Notea.Domain.Users.Models.Requests;
using Notea.Domain.Users.Models.Responses;

namespace Notea.Domain.Users;

public class UserService
{
    private readonly ApplicationDbContext _context;

    private static Expression<Func<User, UserResponse>> MapUserToDtoExpression = user => new UserResponse
    {
        Id = user.Id,
        UserName = user.UserName,
        Email = user.Email,
        FirstName = user.FirstName,
        LastName = user.LastName,
        FullName = user.FullName,
        CreatedAt = user.CreatedAt.ToString(),
        LastLogin = user.LastLogin.ToString()
    };

    public UserService(ApplicationDbContext context) => _context = context;

    public async Task<IList<UserResponse>> GetUsersAsync()
    {
        try
        {
            var users = await _context.Users
                .OrderBy(user => user.Id)
                .Select(MapUserToDtoExpression)
                .ToListAsync();

            return users;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");

            return new List<UserResponse>();
        }
    }

    public async Task<UserResponse> GetUserByIdAsync(string userId)
    {
        try
        {
            var user = await GetUser(userId);

            if (user == null)
            {
                Console.WriteLine($"User with ID {userId} not found.");
                return null;
            }

            return MapUserResponse(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving the user: {ex.Message}");

            return null;
        }
    }


    public async Task<UserResponse> CreateUserAsync(CreateUserRequest newUser)
    {
        try
        {
            // Map the new created user to 'User' entity.
            var user = new User
            {
                UserName = newUser.UserName,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                PasswordHash = HashPassword(newUser.Password),
            };

            // Add the user to the database.
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Map the newly created user back to UserResponse
            return MapUserResponse(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while creating the user: {ex.Message}");

            return null;
        }
    }




    public async Task<UserResponse> UpdateUserAsync(string userId, UpdateUserRequest updateUser)
    {
        try
        {
            bool isModified = false;

            var user = await GetUser(userId);

            if (user == null)
            {
                Console.WriteLine($"User with ID {userId} not found.");
                return null;
            }

            // Check if the new values are different from the current values in the database.
            if (updateUser.UserName != null && user.UserName != updateUser.UserName)
            {
                user.UserName = updateUser.UserName;
                isModified = true;
            }
            if (updateUser.Password != null && user.PasswordHash != updateUser.Password)
            {
                // Hash the password.
                user.PasswordHash = HashPassword(updateUser.Password);
                isModified = true;
            }
            if (updateUser.Email != null && user.Email != updateUser.Email)
            {
                user.Email = updateUser.Email;
                isModified = true;
            }

            // Only update the user if any of the properties have been modified
            if (isModified)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            // Map the User entity back to UserDto
            return MapUserResponse(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while updating the user: {ex.Message}");

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

    private UserResponse MapUserResponse(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null");
        }

        try
        {
            return new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                CreatedAt = user.CreatedAt?.ToString() ?? string.Empty,
                LastLogin = user.LastLogin?.ToString() ?? string.Empty
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while mapping User to UserResponse: {ex.Message}");

            throw;
        }
    }


    private async Task<User?> GetUser(string userId)
    {
        try
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                Console.WriteLine($"User with ID {userId} not found.");
            }

            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving the user with ID {userId}: {ex.Message}");
            return null;
        }
    }


    private string HashPassword(string password) => $"#$§{password}#$§";

}
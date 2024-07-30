using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Notea.Domain.Context;
using Notea.Domain.Users.Requests;
using Notea.Domain.Users.Responses;

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
        var users = await _context.Users.OrderBy(user => user.Id).Select(MapUserToDtoExpression).ToListAsync();

        return users;
    }

    public async Task<UserResponse> GetUserByIdAsync(string userId)
    {
        var user = await GetUser(userId);

        return MapUserResponse(user);
    }

    public async Task<UserResponse> CreateUserAsync(CreateUserRequest newUser)
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

        // Map  the new created user back to UserDto
        return MapUserResponse(user);
    }

    private string HashPassword(string password) => $"#$§{password}#$§";

    public async Task<UserResponse> UpdateUserAsync(string userId, UpdateUserRequest updateUser)
    {
        var user = await GetUser(userId);

        bool isModified = false;

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

    public async Task DeleteUserAsync(string userId)
    {
        var user = await GetUser(userId);

        await _context.Users.Where(u => u.Id == user.Id).ExecuteDeleteAsync();
    }

    private UserResponse MapUserResponse(User user) => new UserResponse
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

    private async Task<User?> GetUser(string userId) =>
        await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == userId);



}
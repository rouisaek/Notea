using Notea.Domain.Contracts;
using Notea.Domain.Dtos.User;
using Notea.Domain.Models;

namespace Notea.Domain.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<GetUserDto>> GetUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();

        return users.Select(MapUserToDto);
    }

    public async Task<GetUserDto> GetUserByIdAsync(string userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        return MapUserToDto(user);
    }

    public async Task<GetUserDto> PostUserAsync(PostUserDto newUser)
    {
        // Map the new created user to 'User' entity.
        var user = new User
        {
            UserName = newUser.Username,
            Email = newUser.Email,
            PasswordHash = newUser.Password
        };

        // Add the user to the database.
        var createdUser = await _userRepository.PostUserAsync(user);

        // Map the createdUser entity back to UserDto
        return MapUserToDto(createdUser);
    }

    public async Task<GetUserDto> UpdateUserAsync(string userId, UpdateUserDto updateUserDto)
    {
        // Get the user from the database.
        var user = await _userRepository.GetUserByIdAsync(userId);

        bool isModified = false;

        // Check if the new values are different from the current values in the database.
        if (updateUserDto.Username != null && user.UserName != updateUserDto.Username)
        {
            user.UserName = updateUserDto.Username;
            isModified = true;
        }
        /*if (updateUserDto.Password != null && user.PasswordHash != updateUserDto.Password)
        {
            // Hash the password.
            user.PasswordHash = HashPassword(updateUserDto.Password);
            isModified = true;
        }*/
        if (updateUserDto.Email != null && user.Email != updateUserDto.Email)
        {
            user.Email = updateUserDto.Email;
            isModified = true;
        }

        // Only update the user if any of the properties have been modified
        if (isModified)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        // Map the User entity back to UserDto
        return MapUserToDto(user);

    }

    public async Task DeleteUserAsync(string userId)
    {
        // Get the User.
        var user = await _userRepository.GetUserByIdAsync(userId);
        await _userRepository.DeleteUserAsync(user);
    }

    private GetUserDto MapUserToDto(User user) => new()
    {
        Id = user.Id,
        Username = user.UserName,
        Email = user.Email,
    };

}
using System.ComponentModel.DataAnnotations;

namespace Notea.Domain.User.Models.Requests;

public class RegisterUserRequest
{
    [Required]
    public required string UserName { get; init; }

    [Required]
    public required string Email { get; init; }

    [Required]
    public required string Password { get; init; }

    [Required]
    public required string FirstName { get; init; }

    [Required]
    public required string LastName { get; init; }
}


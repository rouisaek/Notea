using System.ComponentModel.DataAnnotations;

namespace Notea.Domain.User.Models.Requests;

public class LoginUserRequest
{
    [Required]
    public required string Email { get; init; }

    [Required]
    public required string Password { get; init; }
}
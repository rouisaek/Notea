namespace Notea.Domain.Users.Models.Requests;

public record UpdateUserRequest(string? UserName,
                                string? FirstName,
                                string? LastName,
                                string? Password,
                                string? Email);

namespace Notea.Domain.Users.Requests;

public record UpdateUserRequest(string? UserName,
                                string? FirstName,
                                string? LastName,
                                string? Password,
                                string? Email);

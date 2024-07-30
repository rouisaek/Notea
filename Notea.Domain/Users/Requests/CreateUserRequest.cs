namespace Notea.Domain.Users.Requests;

public record CreateUserRequest(string UserName,
                                string FirstName,
                                string LastName,
                                string Password,
                                string Email);
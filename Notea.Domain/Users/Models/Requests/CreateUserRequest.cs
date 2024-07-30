namespace Notea.Domain.Users.Models.Requests;

public record CreateUserRequest(string UserName,
                                string FirstName,
                                string LastName,
                                string Password,
                                string Email);
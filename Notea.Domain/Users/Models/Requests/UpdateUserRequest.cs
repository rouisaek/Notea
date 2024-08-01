namespace Notea.Domain.Users.Models.Requests;

public class UpdateUserRequest
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
}

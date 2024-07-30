namespace Notea.Domain.Users.Models.Responses;

public class UserResponse
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string CreatedAt { get; set; }
    public string LastLogin { get; set; }
}
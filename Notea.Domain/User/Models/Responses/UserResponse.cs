namespace Notea.Domain.User.Models.Responses;

public class UserResponse
{
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastLogin { get; set; }
}
namespace Notea.Domain.Users.Requests;

// For filtering, searching, or specifying conditions.
public class GetUserRequest
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}
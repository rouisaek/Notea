using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace Notea.Domain.Models.User;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        Id = Guid.NewGuid().ToString("N");
    }

    [Key] public override string Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => string.Join('\u0020', FirstName, LastName);
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.Date;
    public DateTime LastLogin { get; set; } = DateTime.UtcNow;

}
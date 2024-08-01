using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Notea.Domain.Models.Users;

public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => string.Join(" ", FirstName, LastName);
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow.Date;
    public DateTime? LastLogin { get; set; } = DateTime.UtcNow;

}
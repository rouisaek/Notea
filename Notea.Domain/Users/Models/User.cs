using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Notea.Domain.Models.Users;

public class User : IdentityUser
{
    public User()
    {
        Id = Guid.NewGuid().ToString("N");
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key] public override string Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow.Date;
    public DateTime? LastLogin { get; set; } = DateTime.UtcNow;

}
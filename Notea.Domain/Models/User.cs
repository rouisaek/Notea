using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Notea.Domain.Models;

public class User: IdentityUser
{
    public User() => Id = Guid.NewGuid().ToString("N");

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key] public override string Id { get; set; }

}
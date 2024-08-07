using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Notea.Domain.Models.User;

namespace Notea.Domain.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}

using Microsoft.EntityFrameworkCore;
using Notea.Domain.Models.Users;

namespace Notea.Domain.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable(nameof(Users));

        modelBuilder.Entity<User>().HasData
        (
            new User
            {
                UserName = "john_doe",
                Email = "john.doe@example.com",
                FirstName = "John",
                LastName = "Doe",
            }
        );
    }
}

using Notea.Domain.Models;

namespace Notea.Data.Context
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Check if there are any users in the database
            if (context.Users.Any())
            {
                return; // Database has been seeded
            }

            var user1 = new User()
            {
                UserName = "rouisaek",
                Email = "rouisaek@outlook.com",
            };

            context.Users.Add(user1);
            context.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Notea.Domain.Contracts;
using Notea.Domain.Models;
using Notea.Data.Context;

namespace Notea.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsersAsync() => await _context.Users
            .AsQueryable()
                .AsNoTracking()
                    .OrderBy(user => user.Id)
                        .ToListAsync();

    public async Task<User?> GetUserByIdAsync(string userId) => await _context.Users
            .AsQueryable()
                .AsNoTracking()
                    .FirstOrDefaultAsync(user => user.Id == userId);

    public async Task<User> PostUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
    
}

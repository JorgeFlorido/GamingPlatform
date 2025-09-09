using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Persistence;

namespace UserService.Infrastructure.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
      _context = context;
    }

    public async Task AddAsync(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user != null)
      {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
      return await _context.Users
        .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
      return await _context.Users
        .FirstOrDefaultAsync(u => u.Username == username);
    }
  }
}

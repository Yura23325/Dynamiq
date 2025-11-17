using LPNU_Library.Data;
using LPNU_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace LPNU_Library.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
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

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(Guid id) =>
            await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}


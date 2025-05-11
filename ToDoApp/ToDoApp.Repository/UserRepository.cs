using Microsoft.EntityFrameworkCore;
using ToDoApp.Model;

namespace ToDoApp.Repository
{
    public class UserRepository(ToDoDbContext context) : IUserRepository
    {
        public async Task<User?> GetById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task Save(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByUsername(string username)
        {
            return await context.Users.AnyAsync(u => u.Username == username);
        }

    }
}

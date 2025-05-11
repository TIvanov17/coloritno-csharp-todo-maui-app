using Microsoft.EntityFrameworkCore;
using ToDoApp.Model;

namespace ToDoApp.Repository
{
    public class ToDoDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}

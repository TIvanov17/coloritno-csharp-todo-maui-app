using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoApp.Model;

namespace ToDoApp.Repository
{
    public class TaskRepository(ToDoDbContext context) : ITaskRepository
    {
        public async Task Save(Tasks task)
        {
            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
        }
        public async Task Delete(Tasks task)
        {
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }

        public async Task<List<Tasks>> GetTasksByUser(string username)
        {
            var tasks = await context.Tasks
                .Where(t => t.User.Username == username)
                .ToListAsync();

            return tasks;
        }
        
    }
}

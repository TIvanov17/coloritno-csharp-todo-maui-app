
using ToDoApp.Model;

namespace ToDoApp.Repository
{
    public interface ITaskRepository
    {
        Task<List<Tasks>> GetTasksByUser(string username);
        Task Save(Tasks user);
        Task Delete(Tasks user);
    }
}

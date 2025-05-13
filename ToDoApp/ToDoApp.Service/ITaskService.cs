using ToDoApp.Model;

namespace ToDoApp.Service
{
    public interface ITaskService
    {
        Task<Tasks> CreateTask(Tasks task);

        Task<bool> DeleteTask(Tasks task);

        Task<List<Tasks>> GetTasksOfUser(string username);
    }
}

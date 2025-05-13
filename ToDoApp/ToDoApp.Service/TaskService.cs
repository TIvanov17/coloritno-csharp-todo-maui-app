using ToDoApp.Model;
using ToDoApp.Repository;

namespace ToDoApp.Service
{
    public class TaskService(ITaskRepository taskRepository) : ITaskService
    {
        public async Task<Tasks> CreateTask(Tasks task)
        {
            await taskRepository.Save(task);
            return task;
        }

        public async Task<bool> DeleteTask(Tasks task)
        {
            await taskRepository.Delete(task);
            return true;
        }

        public async Task<List<Tasks>> GetTasksOfUser(string username)
        {
            var tasks = await taskRepository.GetTasksByUser(username);
            return tasks;
        }
    }
}

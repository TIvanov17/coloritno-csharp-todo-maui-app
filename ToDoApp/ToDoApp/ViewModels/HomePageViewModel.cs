using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ToDoApp.Model;
using ToDoApp.Service;

namespace ToDoApp.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly ITaskService taskService;
        [ObservableProperty]
        private string newTask;


        [ObservableProperty]
        private string selectedTask;

        public ObservableCollection<Tasks> ToDoItems { get; } = new ObservableCollection<Tasks>();

        public HomePageViewModel(ITaskService taskService)
        {
            this.taskService = taskService;
            LoadTasks();
        }

        public async void LoadTasks()
        {
            var username = await SecureStorage.GetAsync("logged_user");
            var tasks = await taskService.GetTasksOfUser(username);
            ToDoItems.Clear();
            foreach (var task in tasks)
            {
                ToDoItems.Add(task);
            }
        }

        [RelayCommand]
        private async void AddTask()
        {
            if (!string.IsNullOrEmpty(NewTask))
            {
                Tasks task = new()
                {
                    Title = NewTask,
                    IsCompleted = false,
                    UserId = 1
                };

                await taskService.CreateTask(task);
                ToDoItems.Add(task);
                NewTask = string.Empty;
                SelectedTask = task.Title;
            }
        }

        [RelayCommand]
        public async Task DeleteTask(Tasks task)
        {
            Console.WriteLine($"Received task: {task?.Title}");
            await taskService.DeleteTask(task!);
            ToDoItems.Remove(task!);
        }

        [RelayCommand]
        private void ToggleCompletion(Tasks task)
        {
            task.IsCompleted = !task.IsCompleted;
        }

    }
}

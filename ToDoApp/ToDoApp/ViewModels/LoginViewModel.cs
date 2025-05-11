using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoApp.Pages;
using ToDoApp.Service;

namespace ToDoApp.ViewModels
{
    public partial class LoginViewModel(IUserService userService) : ObservableObject
    {

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        private async Task Login()
        {

            if (await userService.Login(Username, Password))
            {
                await Shell.Current.GoToAsync(nameof(HomePage));
                return;
            }

            await Shell.Current.GoToAsync("//RegisterPage");
        }

    }
}

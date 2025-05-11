using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoApp.Pages;
using ToDoApp.Service;

namespace ToDoApp.ViewModels
{
    public partial class RegisterViewModel(IUserService userService) : ObservableObject
    {

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmPassword;

        [ObservableProperty]
        private string message;

        [RelayCommand]
        private async void Register()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                Message = "Please fill in all fields.";
                return;
            }

            if (Password != ConfirmPassword)
            {
                Message = "Passwords do not match.";
                return;
            }

            Message = "Registration successful.";

            await userService.Register(Username, Password);
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        [RelayCommand]
        private async Task NavigateToLogin()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}

using ToDoApp.ViewModels;

namespace ToDoApp.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel viewModel)
    {
		InitializeComponent();
        BindingContext = viewModel;
    }
}
using ToDoApp.ViewModels;

namespace ToDoApp;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel viewModel)
    {
		InitializeComponent();
        BindingContext = viewModel;
    }
}
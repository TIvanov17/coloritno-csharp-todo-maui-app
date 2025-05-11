using ToDoApp.ViewModels;

namespace ToDoApp.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
    {
		InitializeComponent();
        BindingContext = viewModel;
    }
}
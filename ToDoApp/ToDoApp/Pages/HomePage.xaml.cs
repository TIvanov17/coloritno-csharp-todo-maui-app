using ToDoApp.Model;
using ToDoApp.ViewModels;

namespace ToDoApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.CommandParameter as Tasks;

        if (task != null)
        {
            var viewModel = BindingContext as HomePageViewModel;
            await viewModel!.DeleteTask(task);
        }
    }

    private void CheckBox_BindingContextChanged(object sender, EventArgs e)
    {
        var checkBox = (CheckBox)sender;
        
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
       
    }
}
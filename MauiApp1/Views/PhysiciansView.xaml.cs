using Fall2024_Example_Windows.Services;
using Fall2024_Example_Windows.Models;
using MauiApp1.ViewModels;
namespace MauiApp1.Views;

public partial class PhysiciansView : ContentPage
{
	public PhysiciansView()
	{
		InitializeComponent();
		BindingContext = new PhysicianViewModel();
	}

	    private void NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PhysicianViewModel).Search();
    }

    private void SearchClick(object sender, EventArgs e)
    {
        (BindingContext as PhysicianViewModel).Search();
    }

    private void ReturnClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PhysicianDetailsView");
    }

    private void EditClick(object sender, EventArgs e)
    {
        var physicianId = (BindingContext as PhysicianViewModel)?.SelectedPhysician?.Id ?? 0;
        if (physicianId != 0)
        {
            Shell.Current.GoToAsync($"//PhysicianDetailsView?physicianId={physicianId}");

        }
    }

    private void DeleteClick(object sender, EventArgs e)
    {
        (BindingContext as PhysicianViewModel).Delete();
    }
}
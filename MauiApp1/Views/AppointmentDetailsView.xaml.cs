using MauiApp1.ViewModels;
using Fall2024_Example_Windows.Services;
using Fall2024_Example_Windows.Models;
namespace MauiApp1.Views;

[QueryProperty("AppointmentId","appointmentId")]

public partial class AppointmentDetailsView : ContentPage
{
    public int AppointmentId {get; set; }
	public AppointmentDetailsView()
	{
		InitializeComponent();
	}
	private void ReturnClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AppointmentView");
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        Console.WriteLine("submit clicked");
        (BindingContext as AppointmentDetailsViewModel).Add();
        Shell.Current.GoToAsync("//AppointmentView");
    }

    private void AddTreatmentClicked (object sender, EventArgs e)
    {
        (BindingContext as AppointmentDetailsViewModel).AddTreatment();
    }

    private void NavigateTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AppointmentDetailsViewModel(AppointmentId);
    }
}
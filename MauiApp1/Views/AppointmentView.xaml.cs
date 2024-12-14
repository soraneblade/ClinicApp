using MauiApp1.ViewModels;
namespace MauiApp1.Views;

public partial class AppointmentView : ContentPage
{
	public AppointmentView()
	{
		InitializeComponent();

		BindingContext = new AppointmentsViewModel();
	}
	private void NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as AppointmentsViewModel).Search();
    }

    private void SearchClick(object sender, EventArgs e)
    {
        (BindingContext as AppointmentsViewModel).Search();
    }

    private void ReturnClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AppointmentDetailsView");
    }

    private void EditClick(object sender, EventArgs e)
    {
        var appointmentId = (BindingContext as AppointmentsViewModel)?.SelectedAppointment?.Id ?? 0;
        if (appointmentId != 0)
        {
            Console.WriteLine($"Editing Appointment {appointmentId}");
            Shell.Current.GoToAsync($"//AppointmentDetailsView?appointmentId={appointmentId}");

        }
    }

    private void DeleteClick(object sender, EventArgs e)
    {
        (BindingContext as AppointmentsViewModel).Delete();
    }
}
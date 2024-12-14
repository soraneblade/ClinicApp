namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}


	private void ManagePatientsClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PatientsView");
	}
	private void ManagePhysiciansClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PhysiciansView");
	}
	private void ManageAppointmentsClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//AppointmentView");
	}

	private void ManageTreatmentsClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//TreatmentView");
	}
}


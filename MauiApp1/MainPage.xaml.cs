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
}


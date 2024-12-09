using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class PatientsView : ContentPage
{
public PatientsView()
	{
		InitializeComponent();

		BindingContext = new PatientsViewModel();
	}

    private void NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PatientsViewModel).Search();
    }

    private void SearchClick(object sender, EventArgs e)
    {
        (BindingContext as PatientsViewModel).Search();
    }

    private void ReturnClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PatientDetailsView");
    }

    private void EditClick(object sender, EventArgs e)
    {
        var patientId = (BindingContext as PatientsViewModel)?.SelectedPatient?.Id ?? 0;
        if (patientId != 0)
        {
            Shell.Current.GoToAsync($"//PatientDetailsView?patientId={patientId}");

        }
    }

    private void DeleteClick(object sender, EventArgs e)
    {
        (BindingContext as PatientsViewModel).Delete();
    }
}
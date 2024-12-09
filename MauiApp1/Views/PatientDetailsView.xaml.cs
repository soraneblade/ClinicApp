using MauiApp1.ViewModels;
namespace MauiApp1.Views;

[QueryProperty("PatientId","patientId")]
public partial class PatientDetailsView : ContentPage
{
    public int PatientId {get; set; }
	public PatientDetailsView()
	{
		InitializeComponent();
	}

	private void ReturnClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PatientsView");
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        (BindingContext as PatientDetailsViewModel).Add();
        Shell.Current.GoToAsync("//PatientsView");
    }

    private void NavigateTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PatientDetailsViewModel(PatientId);
    }

}
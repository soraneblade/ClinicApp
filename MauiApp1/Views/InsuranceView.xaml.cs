using MauiApp1.ViewModels;

namespace MauiApp1.Views;

[QueryProperty("PatientId","patientId")]
public partial class InsuranceView : ContentPage
{
    public int PatientId {get; set; }
	public InsuranceView()
	{
		InitializeComponent();
	}
	private async void Return(object sender, EventArgs e)
    {
       await Shell.Current.GoToAsync("//PatientsView");
    }

    private async void Submit(object sender, EventArgs e)
    {
        Console.WriteLine("Submit Clicked");
        (BindingContext as InsuranceViewModel).Save();
        await Shell.Current.GoToAsync("//PatientsView");
    }

    private void NavigateTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new InsuranceViewModel(PatientId);
    }
}
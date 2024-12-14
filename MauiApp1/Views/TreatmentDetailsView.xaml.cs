

using MauiApp1.ViewModels;

namespace MauiApp1.Views;

[QueryProperty("TreatmentId","treatmentId")]
public partial class TreatmentDetailsView : ContentPage
{

	public int TreatmentId {get; set; }

	public TreatmentDetailsView()
	{
		InitializeComponent();
	}

	private async void ReturnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//TreatmentView");
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        (BindingContext as TreatmentDetailsViewModel).Add();
        Shell.Current.GoToAsync("//TreatmentView");
    }

    private void NavigateTo(object sender, NavigatedToEventArgs e)
    {
        Console.WriteLine($"TreatmentId : {TreatmentId}");
        BindingContext = new TreatmentDetailsViewModel(TreatmentId);
    }
}
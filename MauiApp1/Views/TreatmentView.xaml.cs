using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class TreatmentView : ContentPage
{
	public TreatmentView()
	{
		InitializeComponent();
		BindingContext = new TreatmentViewModel();
	}
	private void NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as TreatmentViewModel).Search();
    }

    private void SearchClick(object sender, EventArgs e)
    {
        (BindingContext as TreatmentViewModel).Search();
    }

    private void ReturnClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TreatmentDetailsView");
    }

    private void EditClick(object sender, EventArgs e)
    {
        var treatmentId = (BindingContext as TreatmentViewModel)?.SelectedTreatment?.Id ?? 0;
        if (treatmentId != 0)
        {
            Console.WriteLine(treatmentId);
            Shell.Current.GoToAsync($"//TreatmentDetailsView?treatmentId={treatmentId}");

        }
    }

    private void DeleteClick(object sender, EventArgs e)
    {
        (BindingContext as TreatmentViewModel).Delete();
    }
}
using MauiApp1.ViewModels;
namespace MauiApp1.Views;

[QueryProperty("PhysicianId","physicianId")]
public partial class PhysicianDetailsView : ContentPage
{
    public int PhysicianId {get; set; }
	public PhysicianDetailsView()
	{
		InitializeComponent();
	}

	private void ReturnClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PhysiciansView");
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        (BindingContext as PhysicianDetailsViewModel).Add();
        Shell.Current.GoToAsync("//PhysiciansView");
    }

    private void NavigateTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PhysicianDetailsViewModel(PhysicianId);
    }

}
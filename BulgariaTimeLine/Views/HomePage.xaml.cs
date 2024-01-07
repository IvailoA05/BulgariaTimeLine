namespace BulgariaTimeLine;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void btnOngalafight(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OngalaFightPage()).ConfigureAwait(false);
    }
    private async void btnBulgariaCreation(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BulgariaCreationPage()).ConfigureAwait(false);
    }

    private void Button2Tapped(object sender, EventArgs e)
    {
        
    }
}
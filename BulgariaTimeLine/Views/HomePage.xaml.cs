namespace BulgariaTimeLine;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void Button1Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OngalaFightPage()).ConfigureAwait(false);
    }

    private void Button2Tapped(object sender, EventArgs e)
    {
        // Handle the tap event for Button 2
        // Add your logic here
    }
}
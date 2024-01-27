namespace BulgariaTimeLine;

public partial class BulgariaCreationPage : ContentPage
{
    public string YouTubeHtml { get; set; }
    public BulgariaCreationPage()
	{
		InitializeComponent();

        YouTubeHtml = "<html><body><iframe width='100%' height='200' src='https://www.youtube.com/embed/0EHzk2GHLrI' frameborder='0' allowfullscreen></iframe></body></html>";
        BindingContext = this;
    }
}
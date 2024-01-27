namespace BulgariaTimeLine;

public partial class OngalaFightPage : ContentPage
{
    public string YouTubeHtml { get; set; }

    public OngalaFightPage()
	{
		InitializeComponent();

        YouTubeHtml = "<html><body><iframe width='100%' height='200' src='https://www.youtube.com/embed/rMjFy0GMKCw' frameborder='0' allowfullscreen></iframe></body></html>";
        BindingContext = this;
    }
}
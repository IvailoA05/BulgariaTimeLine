namespace BulgariaTimeLine;

public partial class AnhialoBattlePage : ContentPage
{
    public string YouTubeHtml { get; set; }
    public AnhialoBattlePage()
	{
		InitializeComponent();

        YouTubeHtml = "<html><body><iframe width='100%' height='200' src='https://www.youtube.com/embed/NUCwjeW_lp0' frameborder='0' allowfullscreen></iframe></body></html>";
        BindingContext = this;
    }
}
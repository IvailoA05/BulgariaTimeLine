namespace BulgariaTimeLine;

public partial class VerbiPassBattle : ContentPage
{
    public string YouTubeHtml { get; set; }
    public VerbiPassBattle()
	{
		InitializeComponent();

        YouTubeHtml = "<html><body><iframe width='100%' height='200' src='https://www.youtube.com/embed/6gR4O3dSWkE' frameborder='0' allowfullscreen></iframe></body></html>";
        BindingContext = this;
    }
}
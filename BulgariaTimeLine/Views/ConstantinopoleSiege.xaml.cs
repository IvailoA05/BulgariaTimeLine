namespace BulgariaTimeLine;

public partial class ConstantinopoleSiege : ContentPage
{
    public string YouTubeHtml { get; set; }
    public ConstantinopoleSiege()
	{
		InitializeComponent();

        YouTubeHtml = "<html><body><iframe width='100%' height='200' src='https://www.youtube.com/embed/pXFDP5BQ7No' frameborder='0' allowfullscreen></iframe></body></html>";
        BindingContext = this;
    }
}
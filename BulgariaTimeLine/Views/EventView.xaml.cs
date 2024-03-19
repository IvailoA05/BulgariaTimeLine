using BulgariaTimeLine.Services;
using BulgariaTimeLine.Models;

namespace BulgariaTimeLine;

public partial class EventView : ContentPage
{
    private readonly DatabaseHelper _databaseHelper;
    public string YouTubeHtml { get; set; }
    public Event Event { get; set; }
    public EventView(int id)
	{
		InitializeComponent();
        _databaseHelper = new DatabaseHelper();
        var allEvents = _databaseHelper.GetEvents();
        Event = allEvents.FirstOrDefault(e => e.EventId == id);
        YouTubeHtml = $"<html><body><iframe width='100%' height='200' src='{Event.Video}' frameborder='0' allowfullscreen></iframe></body></html>";
        BindingContext = this;
    }
}
using BulgariaTimeLine.Services;
using BulgariaTimeLine.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BulgariaTimeLine;

public partial class HomePage : ContentPage
{
    private List<Event> Events;
    private readonly DatabaseHelper _databaseHelper;
    public HomePage()
    {
        InitializeComponent();
        _databaseHelper = new DatabaseHelper();
        LoadEvents();
        searchBar.TextChanged += OnSearchTextChanged;
    }
    private void LoadEvents()
    {
        Events = _databaseHelper.GetEvents();
        eventListView.ItemsSource = Events;
    }
    private async void onEventSelected(object sender, EventArgs e)
    {
        var Parameter = ((TappedEventArgs)e).Parameter;
        await Navigation.PushAsync(new EventView((int)Parameter)).ConfigureAwait(false);
    }
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue.ToLower();
        if (string.IsNullOrWhiteSpace(searchText))
        {
            if (eventListView.Parent != null)
            {
                eventListView.ItemsSource = Events;
            }
            if (notFoundLayout.Parent != null)
            {
                notFoundLayout.IsVisible = false;
            }
        }
        else
        {
            var filteredEvents = Events.Where(ev => ev.Title.ToLower().Contains(searchText) || ev.Year.ToLower().Contains(searchText) || ev.Tags.ToLower().Contains(searchText)).ToList();
            if (filteredEvents.Any())
            {
                if (eventListView.Parent != null)
                {
                    eventListView.ItemsSource = filteredEvents;
                }
                if (notFoundLayout.Parent != null)
                {
                    notFoundLayout.IsVisible = false;
                }
            }
            else
            {
                if (eventListView.Parent != null)
                {
                    eventListView.ItemsSource = new List<Event>();
                }
                if (notFoundLayout.Parent != null)
                {
                    notFoundLayout.IsVisible = true;
                }
            }
        }
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        searchBar.TextChanged -= OnSearchTextChanged;
    }

    private async void LogoutButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage()).ConfigureAwait(false);
    }
    private async void ReportBugButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReportPage()).ConfigureAwait(false);
    }

    private async void btnOngalafight(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OngalaFightPage()).ConfigureAwait(false);
    }

    private async void btnBulgariaCreation(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BulgariaCreationPage()).ConfigureAwait(false);
    }

    private async void btnAnhialoBattle(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AnhialoBattlePage()).ConfigureAwait(false);
    }
    private async void btnConstantinopoleSiege(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConstantinopoleSiege()).ConfigureAwait(false);
    }
    private async void btnVerbiPassBattle(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerbiPassBattle()).ConfigureAwait(false);
    }
    private async void AddButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReportPage()).ConfigureAwait(false);
    }
}

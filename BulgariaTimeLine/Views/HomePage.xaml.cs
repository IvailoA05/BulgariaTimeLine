using BulgariaTimeLine.Services;
using BulgariaTimeLine.Models;

namespace BulgariaTimeLine;

public partial class HomePage : ContentPage
{
    private List<CenturyEvent> CenturyEvents;
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
        var centuryEvents = new List<CenturyEvent>();

        foreach (var group in _databaseHelper.GetEvents()
                                    .OrderBy(x => x.Year)
                                    .GroupBy(x => GetCentury(int.Parse(x.Year))))

        {
            var centuryEvent = new CenturyEvent
            {
                Century = group.Key,
                Events = group.ToList()
            };

            centuryEvents.Add(centuryEvent);
        }
        CenturyEvents = centuryEvents;
        // Now centuryEvents is a List<CenturyEvent>
        eventListView.ItemsSource = CenturyEvents;
    }
    private string GetCentury(int year)
    {
        // Calculate the century
        int century = (year - 1) / 100 + 1;

        // Convert the century to Roman numeral
        string romanNumeral = "";

        switch (century)
        {
            case 1:
                romanNumeral = "I";
                break;
            case 2:
                romanNumeral = "II";
                break;
            case 3:
                romanNumeral = "III";
                break;
            case 4:
                romanNumeral = "IV";
                break;
            case 5:
                romanNumeral = "V";
                break;
            case 6:
                romanNumeral = "VI";
                break;
            case 7:
                romanNumeral = "VII";
                break;
            case 8:
                romanNumeral = "VIII";
                break;
            case 9:
                romanNumeral = "IX";
                break;
            case 10:
                romanNumeral = "X";
                break;
            case 11:
                romanNumeral = "XI";
                break;
            case 12:
                romanNumeral = "XII";
                break;
            case 13:
                romanNumeral = "XIII";
                break;
            case 14:
                romanNumeral = "XIV";
                break;
            case 15:
                romanNumeral = "XV";
                break;
            case 16:
                romanNumeral = "XVI";
                break;
            case 17:
                romanNumeral = "XVII";
                break;
            case 18:
                romanNumeral = "XVIII";
                break;
            case 19:
                romanNumeral = "XIX";
                break;
            case 20:
                romanNumeral = "XX";
                break;
            case 21:
                romanNumeral = "XXI";
                break;
        }

        return romanNumeral;
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
                eventListView.ItemsSource = CenturyEvents;
            }
            if (notFoundLayout.Parent != null)
            {
                notFoundLayout.IsVisible = false;
            }
        }
        else
        {
            var filteredEvents = CenturyEvents
     .SelectMany(centuryEvent => centuryEvent.Events) // Flatten the list of events within CenturyEvent objects
     .Where(ev =>
         ev.Title.ToLower().Contains(searchText.ToLower()) ||  // Check if title contains searchText

         ev.Year.ToString().Contains(searchText) || // Check if year contains searchText

         ev.Tags.ToLower().Contains(searchText.ToLower())) // Check if tags contain searchText
     .ToList();

            var centuryEvents = new List<CenturyEvent>();

            foreach (var group in filteredEvents
                                        .OrderBy(x => x.Year)
                                        .GroupBy(x => GetCentury(int.Parse(x.Year))))

            {
                var centuryEvent = new CenturyEvent
                {
                    Century = group.Key,
                    Events = group.ToList()
                };

                centuryEvents.Add(centuryEvent);
            }
            if (centuryEvents.Any())
            {
                if (eventListView.Parent != null)
                {
                    eventListView.ItemsSource = centuryEvents;
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
                    eventListView.ItemsSource = new List<CenturyEvent>();
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

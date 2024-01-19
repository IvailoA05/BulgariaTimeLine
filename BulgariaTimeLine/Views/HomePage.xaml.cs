namespace BulgariaTimeLine;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchQuery = e.NewTextValue;

        // Filter the content based on the search query
        FilterContent(searchQuery);
    }

    private void FilterContent(string searchQuery)
    {
        // Flag to determine if there is any match
        bool hasMatch = false;

        // Iterate through the children of the VerticalStackLayout
        foreach (var child in stackLayout.Children)
        {
            // Check if the child is a Frame
            if (child is Frame frame)
            {
                // Check if the Frame contains a StackLayout
                if (frame.Content is StackLayout stackLayoutInsideFrame)
                {
                    // Iterate through the children of the StackLayout
                    foreach (var element in stackLayoutInsideFrame.Children)
                    {
                        // Check if the element is a Label or a Button
                        if (element is Label label)
                        {
                            // Check if the label's text contains the search query
                            bool isMatch = label.Text.Contains(searchQuery, StringComparison.OrdinalIgnoreCase);

                            // Update the visibility of the Frame based on the search result
                            frame.IsVisible = isMatch;

                            // Update the flag
                            hasMatch = hasMatch || isMatch;

                            // Break the loop if there is a match to avoid unnecessary iterations
                            if (isMatch)
                                break;
                        }
                        else if (element is Button button)
                        {
                            // Check if the button's text contains the search query
                            bool isMatch = button.Text.Contains(searchQuery, StringComparison.OrdinalIgnoreCase);

                            // Update the visibility of the Frame based on the search result
                            frame.IsVisible = isMatch;

                            // Update the flag
                            hasMatch = hasMatch || isMatch;

                            // Break the loop if there is a match to avoid unnecessary iterations
                            if (isMatch)
                                break;
                        }
                    }
                }
            }
        }

        // Show/hide the "Not found" layout based on search results
        notFoundLayout.IsVisible = !hasMatch;
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

    private void Button2Tapped(object sender, EventArgs e)
    {

    }
    private async void AddButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReportPage()).ConfigureAwait(false);
    }
}

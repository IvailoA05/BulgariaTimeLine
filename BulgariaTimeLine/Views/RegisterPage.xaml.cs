using BulgariaTimeLine.Models;
using BulgariaTimeLine.Services;

namespace BulgariaTimeLine;

public partial class RegisterPage : ContentPage
{
    private DatabaseHelper _databaseHelper = new DatabaseHelper();
    public RegisterPage()
	{
		InitializeComponent();
	}
    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string username = EmailEntry.Text;
        string password = PasswordEntry.Text;
        string confirmpassword = ConfirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmpassword))
        {
            await DisplayAlert("Грешка!", "Моля попълнете всички полета!", "OK");
            return;
        }
        if (password != confirmpassword)
        {
            await DisplayAlert("Грешка!", "Паролите не съвпадат!", "OK");
            return;
        }
        // Check if the username is already taken
        if (_databaseHelper.ValidateUser(username, password))
        {
            await DisplayAlert("Грешка!", "Потребителското име вече е заето!", "OK");
            return;
        }
        var newUser = new User
        {
            Username = username,
            Password = password
        };

        _databaseHelper.InsertUser(newUser);
        await Navigation.PushAsync(new MainPage()).ConfigureAwait(false);
    }
    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
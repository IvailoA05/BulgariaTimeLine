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
        if (!IsPasswordValid(password))
        {
            await DisplayAlert("Грешка!", "Паролата трябва да е поне 8 символа и да съдържа поне една цифра и една буква!", "OK");
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
    private bool IsPasswordValid(string password)
    {
        // Check if password length is at least 8 characters
        if (password.Length < 8)
            return false;

        // Check if password contains at least one letter and one digit
        bool hasLetter = false;
        bool hasDigit = false;
        foreach (char c in password)
        {
            if (char.IsLetter(c))
                hasLetter = true;
            else if (char.IsDigit(c))
                hasDigit = true;

            // If both conditions are met, exit the loop early
            if (hasLetter && hasDigit)
                break;
        }

        return hasLetter && hasDigit;
    }
    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
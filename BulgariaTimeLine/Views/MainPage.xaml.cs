using BulgariaTimeLine.Models;
using BulgariaTimeLine.Services;

namespace BulgariaTimeLine;

public partial class MainPage : ContentPage
{
        private DatabaseHelper _databaseHelper = new DatabaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            List<User> message = _databaseHelper.GetUsers();
            string secondMessage = "";
   
            foreach (var user in message)
            {
            secondMessage += user.Username;
            }
            if (username == null || password == null)
            {
            await DisplayAlert("Грешка!",secondMessage, "OК");
            return;
            }
            if (username == "admin" && password == "1234567")
            {
            await Navigation.PushAsync(new HomePage()).ConfigureAwait(false);
            }
            else if (_databaseHelper.ValidateUser(username, password))
            {
            // Successful login, navigate to the main page
            await Navigation.PushAsync(new HomePage()).ConfigureAwait(false);
            }
            else
            {
            // Display an error message for unsuccessful login
            await DisplayAlert("Грешка!", "Невалидно име или парола!", "OK").ConfigureAwait(false);
            }
        }
         private async void CreateAccountButtonClicked(object sender, EventArgs e)
         {
           await Navigation.PushAsync(new RegisterPage());
         }
}


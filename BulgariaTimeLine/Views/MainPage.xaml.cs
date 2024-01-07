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
 
            if (username == null || password == null)
            {
            await DisplayAlert("Грешка!","Моля попълнете всички полета!", "OК");
            return;
            }
            if (username == "admin" && password == "1234567")
            {
            await Navigation.PushAsync(new AdminPage()).ConfigureAwait(false);
            }
            else if (_databaseHelper.ValidateUser(username, password))
            {
            await Navigation.PushAsync(new HomePage()).ConfigureAwait(false);
            }
            else
            {
            await DisplayAlert("Грешка!", "Невалидно име или парола!", "OK").ConfigureAwait(false);
            }
        }
         private async void CreateAccountButtonClicked(object sender, EventArgs e)
         {
           await Navigation.PushAsync(new RegisterPage());
         }
}


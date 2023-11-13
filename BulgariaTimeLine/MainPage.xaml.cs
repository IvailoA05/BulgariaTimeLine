namespace BulgariaTimeLine;

public partial class MainPage : ContentPage
{
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            if (username == null || password == null)
            {
            DisplayAlert("Грешка!", "Моля, въведете име и парола!", "OК");
            return;
            }
            // Perform your login logic here, e.g., validate credentials, navigate to the main page, or show an error message.
        }
         private async void CreateAccountButtonClicked(object sender, EventArgs e)
         {
           await Navigation.PushAsync(new RegisterPage());
         }
}


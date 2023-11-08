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

            // Perform your login logic here, e.g., validate credentials, navigate to the main page, or show an error message.
        }
         private void OnForgotPasswordButtonClicked(object sender, EventArgs e)
         {
        // Implement the logic for the "Forgot Password" action here
         }
}


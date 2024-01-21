using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BulgariaTimeLine;

public partial class ReportPage : ContentPage
{
    public ICommand SubmitCommand { get; }
    public ReportPage()
	{
		InitializeComponent();
        SubmitCommand = new Command(async () => await OnSubmitClicked());
        BindingContext = this;
    }
    private async Task OnSubmitClicked()
    {
            if (string.IsNullOrWhiteSpace(EmailEntry.Text) || !IsValidEmail(EmailEntry.Text))
            {
                await DisplayAlert("Грешка!", "Моля въведете валиден имейл.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(TitleEntry.Text))
            {
                await DisplayAlert("Грешка!", "Моля въведете заглавие.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionEditor.Text))
            {
                await DisplayAlert("Грешка!", "Моля въведте описание на проблема.", "OK");
                return;
            }
            var formData = new
            {
                email = EmailEntry.Text,
                title = TitleEntry.Text,
                description = DescriptionEditor.Text
            };
            // Call the method to send the email via SMTP
            bool success = await SendEmailViaSmtpAsync(formData.email, formData.title, formData.description);

            if (success)
            {
                await DisplayAlert("Готово!", $"Изпратихте заявката си успешно!\nЩе се свържем с вас в най-кратък срок, на посочения от вас имейл:\n{formData.email}.", "OK");
            }
            else
            {
                await DisplayAlert("Грешка!", "Заявката ви не беше изпратена!\n Моля опитайте отново по-късно.", "OK");
            }
    }
    // Email validation method
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    private async Task<bool> SendEmailViaSmtpAsync(string to, string subject, string body)
    {
        try
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "bulgariatimeline@gmail.com";
            string smtpPassword = "geap idhs axad yxtu";

            using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(to);
                await client.SendMailAsync(mailMessage);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
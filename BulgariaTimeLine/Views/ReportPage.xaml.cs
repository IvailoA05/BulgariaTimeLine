namespace BulgariaTimeLine;

public partial class ReportPage : ContentPage
{
	public ReportPage()
	{
		InitializeComponent();
	}
    private void OnSubmitClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EmailEntry.Text) || !IsValidEmail(EmailEntry.Text))
        {
            DisplayAlert("������!", "���� �������� ������� �����.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            DisplayAlert("������!", "���� �������� ��������.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(DescriptionEditor.Text))
        {
            DisplayAlert("������!", "���� ������� �������� �� ��������.", "OK");
            return;
        }
        // Retrieve the entered data
        string email = EmailEntry.Text;
        string title = TitleEntry.Text;
        string description = DescriptionEditor.Text;

        DisplayAlert("������!", $"���������� ������ ������ �������!\n�� �� ������� � ��� � ���-������ ����, �� ��������� �� ��� �����:\n{email}", "OK");
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
}
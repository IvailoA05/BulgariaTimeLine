using BulgariaTimeLine.Models;
using BulgariaTimeLine.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulgariaTimeLine;

public partial class AdminPage : ContentPage
{
    private DatabaseHelper _databaseHelper = new DatabaseHelper();
    public AdminPage()
	{
		InitializeComponent();
		userListView.ItemsSource = _databaseHelper.GetUsers();
    }
    private async void LogoutButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage()).ConfigureAwait(false);
    }
    private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var user = (User)e.Item;
        var action = await DisplayActionSheet("Изберете опция", "Откажи", null, "Редактирай", "Изтрий");

        switch (action)
        {
            case "Редактирай":
                _editId = user.Id;
                usernameEntryField.Text = user.Username;
                passwordEntryField.Text = user.Password;
                break;
            case "Изтрий":
                _databaseHelper.DeleteUser(user);
                userListView.ItemsSource = _databaseHelper.GetUsers();
                break;
        }
    }
    private int _editId = 0;
    private void SaveButtonClicked(object sender, EventArgs e)
    {
        string username = usernameEntryField.Text;
        string password = passwordEntryField.Text;
        var newUser = new User
        {
            Username = username,
            Password = password
        };
        if (_editId == 0)
        {
            _databaseHelper.InsertUser(newUser);
        }
        else
        {
            var existingUser = _databaseHelper.GetUsers().FirstOrDefault(u => u.Id == _editId);
            if (existingUser != null)
            {
                // Update existing user with new values
                existingUser.Username = newUser.Username;
                existingUser.Password = newUser.Password;

                // Save changes to the database
                _databaseHelper.UpdateUser(existingUser);
            }
        }
        //Clearing the fields after operation
        usernameEntryField.Text = String.Empty;
        passwordEntryField.Text = String.Empty;
        //Reloading the user list
        userListView.ItemsSource = _databaseHelper.GetUsers();
    }
    private async void EditorButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditorPage()).ConfigureAwait(false);
    }
}
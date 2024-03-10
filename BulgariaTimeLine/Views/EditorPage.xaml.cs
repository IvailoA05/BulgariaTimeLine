using BulgariaTimeLine.Services;
using BulgariaTimeLine.Models;
using System.ComponentModel.DataAnnotations.Schema;
//using static Android.Print.PrintAttributes;

namespace BulgariaTimeLine;

public partial class EditorPage : ContentPage
{
    private DatabaseHelper _databaseHelper = new DatabaseHelper();
    //private MediaFile _selectedImageFile;
    public EditorPage()
	{
		InitializeComponent();
        eventListView.ItemsSource = _databaseHelper.GetEvents();
    }
    //private async void SelectImageButton_Clicked(object sender, EventArgs e)
    //{
    //    //var mediaPicker = new MediaPicker();
    //    //_selectedImageFile = await mediaPicker.PickPhotoAsync();

    //    //if (_selectedImageFile != null)
    //    {
    //        //eventImage.Source = ImageSource.FromStream(() => _selectedImageFile.OpenReadAsync().Result);
    //    }
    //}
    private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var _event = (Event)e.Item;
        var action = await DisplayActionSheet("Select an option", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":
                _editId = _event.EventId;
                titleEntryField.Text = _event.Title;
                yearEntryField.Text = _event.Year;
                tagsEntryField.Text = _event.Tags;
                textEntryField.Text = _event.Text;
               // eventImage.Source = ImageSource.FromStream(() => new MemoryStream(_event.Image));
                videoEntryField.Text = _event.Video;
                break;
            case "Delete":
                _databaseHelper.DeleteEvent(_event);
                eventListView.ItemsSource = _databaseHelper.GetEvents();
                break;
        }
    }
    private int _editId = 0;

    private void SaveButtonClicked(object sender, EventArgs e)
    {
        string title = titleEntryField.Text;
        string year = yearEntryField.Text;
        string tags = tagsEntryField.Text;
        string text = textEntryField.Text;
        //Da imzislq kak da stane tva sus snimkata
        string video = videoEntryField.Text;
        var newEvent = new Event
        {
            Title = title,
            Year = year,
            Tags = tags,
            Text = text,
            //Snimkata tuk
            Video = video,
        };
        if (_editId == 0)
        {
            _databaseHelper.InsertEvent(newEvent);
        }
        else
        {
            var existingEvent = _databaseHelper.GetEvents().FirstOrDefault(u => u.EventId == _editId);
            if (existingEvent != null)
            {
                // Update existing event with new values
                existingEvent.Title = newEvent.Title;
                existingEvent.Year = newEvent.Year;
                existingEvent.Tags = newEvent.Tags;
                existingEvent.Text = newEvent.Text;
                //Snimkata
                existingEvent.Video = newEvent.Video;

                // Save changes to the database
                _databaseHelper.UpdateEvent(existingEvent);
            }
        }
        //Clearing the fields after operation
        titleEntryField.Text = String.Empty;
        yearEntryField.Text = String.Empty;
        tagsEntryField.Text = String.Empty;
        textEntryField.Text = String.Empty;
        videoEntryField.Text = String.Empty;
        //Reloading the user list
        eventListView.ItemsSource = _databaseHelper.GetEvents();
    }
}
using BulgariaTimeLine.Services;

namespace BulgariaTimeLine;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
    static DatabaseHelper database;

    // Create the database connection as a singleton.
    public static DatabaseHelper Database
    {
        get
        {
            if (database == null)
            {
                database = new DatabaseHelper();
            }
            return database;
        }
    }
}

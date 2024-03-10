using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulgariaTimeLine.Models;

namespace BulgariaTimeLine.Services
{
    public class DatabaseHelper
    {
        SQLiteConnection Database;
        public DatabaseHelper()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HistoryApp.db3");
            Database = new SQLiteConnection(dbPath);
            Database.CreateTable<User>();
            Database.CreateTable<Event>();
        }
        public void InsertUser(User user)
        {
            Database.Insert(user);
        }
        public void UpdateUser(User user)
        {
            Database.Update(user);
        }
        public void DeleteUser(User user)
        {
            Database.Delete(user);
        }

        public bool ValidateUser(string username, string password)
        {
            var user = Database.Table<User>().FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // User with the provided credentials exists
                Console.WriteLine("User validated: " + user.Username);
                return true;
            }
            else
            {
                // No user found with the provided credentials
                Console.WriteLine("Invalid credentials");
                return false;
            }
        }
        public List<User> GetUsers()
        {
            var res = Database.Table<User>().ToList();
            return res;
        }

        public void InsertEvent(Event _event)
        {
            Database.Insert(_event);
        }

        public void UpdateEvent(Event _event)
        {
            Database.Update(_event);
        }

        public void DeleteEvent(Event _event)
        {
            Database.Delete(_event);
        }

        public List<Event> GetEvents()
        {
            var res = Database.Table<Event>().ToList();
            return res;
        }
    }
}

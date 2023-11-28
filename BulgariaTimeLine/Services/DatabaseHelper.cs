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
        }
        public void InsertUser(User user)
        {
            Database.Insert(user);
        }
        public bool ValidateUser(string username, string password)
        {
            var user = Database.Table<User>().ToList();
            Console.WriteLine(String.Join("", user));
            return false;
        }
        public List<User> GetUsers()
        {
            var res = Database.Table<User>().ToList();
            return res;
        }
    }
}

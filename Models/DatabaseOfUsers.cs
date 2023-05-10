using SQLite;

namespace ContactList.Models
{
    public class DatabaseOfUsers
    {
        string _dbPath;
        private SQLiteConnection conn;

        public DatabaseOfUsers(string dbPath)
        {
            _dbPath = dbPath;

        }
        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
        }
    }
}

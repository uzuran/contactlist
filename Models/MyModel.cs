using SQLite;


namespace ContactList.Models
{
    public class MyModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int password { get; set; }
    }
}

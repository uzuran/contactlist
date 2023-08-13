using Microsoft.EntityFrameworkCore;

namespace ContactList.Models
{
    public class UserDataContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }        

        public UserDataContext(DbContextOptions<UserDataContext> dbContextOptions): base(dbContextOptions)
        {            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
        }
    }
}
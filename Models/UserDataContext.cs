using Microsoft.EntityFrameworkCore;


namespace ContactList.Models
{
    public class UserDataContext : DbContext
    {
        static readonly string connectionString = "Server=aws.connect.psdb.cloud;Database=contactlist;user=7s6zwuwvms0el0kbqwtt;password=pscale_pw_PXpnN1adShoXBnfbwPDPto3c0fLW366NF0Thfi8WUJd;SslMode=Required;";

        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
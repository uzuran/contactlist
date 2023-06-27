using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

        // Here, i try to read connection string from appsettings.json file. ------->>>

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        // Build configuration
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory()) // NuGet Microsoft.Extensions.Configuration.Json
        //            .AddJsonFile("appsettings.json")
        //            .Build();

        //        // Get connection string from appsettings.json
        //        string connectionString = configuration.GetConnectionString("Default");

        //        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //    }
        //}


    }
}
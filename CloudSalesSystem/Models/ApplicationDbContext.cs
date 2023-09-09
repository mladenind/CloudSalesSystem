using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Models
{
    public class ApplicationDbContext: DbContext
    {
        protected readonly IConfiguration? Configuration;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("AppDb");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}

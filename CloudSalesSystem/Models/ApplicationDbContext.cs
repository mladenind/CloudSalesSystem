using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Models
{
    public class ApplicationDBContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDBContext(IConfiguration configuration)
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
    }
}

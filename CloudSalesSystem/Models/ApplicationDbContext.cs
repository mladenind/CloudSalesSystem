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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Customer>()
                .HasData(new Customer
                {
                    Id = 1,
                    Email = "supercustomer@crayon.com",
                    Name = "Super Customer",
                }
            );

            modelBuilder.Entity<Account>()
                .HasData(
                new Account
                {
                    Id = 1,
                    Name = "First Test Account",
                    CustomerId = 1
                },
                new Account
                {
                    Id = 2,
                    Name = "Second Test Account",
                    CustomerId = 1
                },
                new Account
                {
                    Id = 3,
                    Name = "Second Test Account",
                    CustomerId = 1
                }
            );
        }
    }
}

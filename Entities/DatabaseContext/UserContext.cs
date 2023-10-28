
using Entities.Configuration;
using Entities.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Repository.DatabaseContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}

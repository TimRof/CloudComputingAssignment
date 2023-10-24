using Entities.Models.Mortgage;
using Microsoft.EntityFrameworkCore;

namespace Repository.DatabaseContext
{
    public class MortgageApplicationContext : DbContext
    {
        public MortgageApplicationContext(DbContextOptions<MortgageApplicationContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }

        public DbSet<MortgageApplication> MortgageApplication { get; set; }
    }
}

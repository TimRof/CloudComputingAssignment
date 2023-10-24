using Entities.Models.Mortgage;
using Microsoft.EntityFrameworkCore;

namespace Repository.DatabaseContext
{
    public class MortgageContext : DbContext
    {
        public MortgageContext(DbContextOptions<MortgageContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }

        public DbSet<MortgageApplication> MortgageApplications { get; set; }
        public DbSet<MortgageOffer> MortgageOffers { get; set; }
    }
}

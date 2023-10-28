using Entities.Models.Mortgage;
using Entities.Models.User;
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
            //modelBuilder.ApplyConfiguration(new MortgageConfiguration());
        }

        public DbSet<MortgageApplication> MortgageApplications { get; set; }
        public DbSet<MortgageOffer> MortgageOffers { get; set; }
    }
}

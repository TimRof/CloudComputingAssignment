using Entities.Models.Listing;
using Microsoft.EntityFrameworkCore;

namespace Repository.DatabaseContext
{
    public class ListingContext : DbContext
    {
        public ListingContext(DbContextOptions<ListingContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new ListingConfiguration());
        }

        public DbSet<PropertyListing> Listings { get; set; }
    }
}

using Entities.Models.Listing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Entities.Configuration
{
    internal class PropertyListingConfiguration : IEntityTypeConfiguration<PropertyListing>
    {
        public void Configure(EntityTypeBuilder<PropertyListing> builder)
        {
            builder.HasData(
                new PropertyListing
                {
                    Price = 500000,
                    Address = "123 Test Street",
                    City = "Test City",
                    Region = "Test Region",
                    ImageName = "default.png"
                },
                new PropertyListing
                {
                    Price = 750000,
                    Address = "456 Sample Avenue",
                    City = "Sample Town",
                    Region = "Sample Region",
                    ImageName = "sample.png"
                },
                new PropertyListing
                {
                    Price = 600000,
                    Address = "789 Example Road",
                    City = "Exampleville",
                    Region = "Example State",
                    ImageName = "example.png"
                }
            );
        }
    }
}

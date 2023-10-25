namespace Entities.Models.Listing
{
    public class PropertyListing : IListing
    {
        public Guid Id { get; set; } = EntityBaseExtensions.GenerateId();

        public decimal Price { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string ImageName { get; set; }


        public PropertyListing()
        { }
    }
}
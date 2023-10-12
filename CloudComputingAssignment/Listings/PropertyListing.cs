namespace Models.Listings
{
    public class PropertyListing : IListing
    {
        public Guid Id { get; } = EntityBaseExtensions.GenerateId();

        public decimal Price { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public PropertyListing()
        { }
    }
}
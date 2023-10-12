namespace Models.Listings
{
    public interface IListing : IEntityBase
    {
        public decimal Price { get; set; }
    }
}
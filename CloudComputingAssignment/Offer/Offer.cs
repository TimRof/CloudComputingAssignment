using Models.Listings;
using Models.Users;

namespace Models.Offer
{
    public class Offer : IEntityBase
    {
        public Guid Id { get; } = EntityBaseExtensions.GenerateId();

        public IUser OfferMaker { get; set; }

        public IListing Listing { get; set; }

        public Decimal ListedPrice { get; set; }

        public Decimal OfferedPrice { get; set; }

        public DateTime TimeOfOffer { get; set; }

        public Offer()
        { }
    }
}
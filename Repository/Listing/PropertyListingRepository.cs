using Repository.DatabaseContext;
using Entities;
using Entities.Models.General;
using Entities.Models.Listing;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PropertyListingRepository : BaseRepository<ListingContext, PropertyListing>, IPropertyListingRepository
    {
        public PropertyListingRepository(ListingContext listingContext) : base(listingContext)
        {
        }
        public virtual IEnumerable<PropertyListing> GetAllByPriceRange(PriceRange priceRange, int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;

            return _context
                .Set<PropertyListing>().AsEnumerable()
                .Where(p => p.Price >= priceRange.MinPrice && p.Price <= priceRange.MaxPrice)
                .Skip(skip)
                .Take(pageSize);
        }
    }
}
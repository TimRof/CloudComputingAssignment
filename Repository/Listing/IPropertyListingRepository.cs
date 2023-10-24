using Entities.Models.General;
using Entities.Models.Listing;
using Repository.DatabaseContext;

namespace Repository
{
    public interface IPropertyListingRepository : IBaseRepository<ListingContext, PropertyListing>
    {
        IEnumerable<PropertyListing> GetAllByPriceRange(PriceRange priceRange, int page, int pageSize);
    }
}
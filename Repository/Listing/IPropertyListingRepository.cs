using Entities.Models.General;
using Entities.Models.Listing;
using Repository.DatabaseContext;

namespace Repository
{
    public interface IPropertyListingRepository : IBaseRepository<ListingContext, PropertyListing>
    {
        Task<IEnumerable<PropertyListing>> GetAllByPriceRangeAsync(PriceRange priceRange, int page, int pageSize);
    }
}
using Entities.Models.General;
using Entities.Models.Listing;

namespace ServiceLayer.Listing
{
    public interface IListingService<T> : IBaseService<T> where T : IListing
    {
        IEnumerable<T> GetAllByPriceRange(PriceRange priceRange, int page, int pageSize);
    }
}
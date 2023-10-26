using Entities.Models.General;
using Entities.Models.Listing;

namespace ServiceLayer.Listing
{
    public interface IListingService<T> : IBaseService<T> where T : IListing
    {
        Task<IEnumerable<T>> GetAllByPriceRangeAsync(PriceRange priceRange, int page, int pageSize);
    }
}
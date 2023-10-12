using Models.General;
using Models.Listings;

namespace ServiceLayer.Listings
{
    public interface IListingService<T> : IBaseService<T> where T : IListing
    {
        IEnumerable<T> GetAllByPriceRange(PriceRange priceRange, int page, int pageSize);
    }
}
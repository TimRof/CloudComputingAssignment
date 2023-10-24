using Entities.Models.General;
using Entities.Models.Listing;
using Repository;

namespace ServiceLayer.Listing
{
    public class PropertyListingService : IListingService<PropertyListing>
    {
        private readonly IPropertyListingRepository _repository;

        public PropertyListingService(IPropertyListingRepository repository)
        {
            _repository = repository;
        }
        public void Add(PropertyListing listing)
        {
            _repository.Add(listing);
            _repository.Commit();
        }

        public PropertyListing Get(Guid id)
        {
            return _repository.GetSingle(id);
        }

        public IEnumerable<PropertyListing> GetAll(int page = 1, int pageSize = 10)
        {
            return _repository.GetAll(page, pageSize);
        }

        public IEnumerable<PropertyListing> GetAllByPriceRange(PriceRange priceRange, int page = 1, int pageSize = 10)
        {
            return _repository.GetAllByPriceRange(priceRange, page, pageSize);
        }
    }
}
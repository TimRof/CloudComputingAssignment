using Entities.Models.General;
using Entities.Models.Listing;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Listing
{
    public class PropertyListingService : IListingService<PropertyListing>
    {
        private readonly IPropertyListingRepository _repository;

        public PropertyListingService(IPropertyListingRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(PropertyListing listing)
        {
            await _repository.AddAsync(listing);
            await _repository.CommitAsync();
        }

        public async Task<PropertyListing> GetAsync(Guid id)
        {
            return await _repository.GetSingleAsync(id);
        }

        public async Task<IEnumerable<PropertyListing>> GetAllAsync(int page = 1, int pageSize = 10)
        {
            return await _repository.GetAllAsync(page, pageSize);
        }

        public async Task<IEnumerable<PropertyListing>> GetAllByPriceRangeAsync(PriceRange priceRange, int page = 1, int pageSize = 10)
        {
            return await _repository.GetAllByPriceRangeAsync(priceRange, page, pageSize);
        }
    }
}

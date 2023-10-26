using Entities;
using Entities.Models.General;
using Entities.Models.Listing;
using Microsoft.EntityFrameworkCore;
using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class PropertyListingRepository : BaseRepository<ListingContext, PropertyListing>, IPropertyListingRepository
    {
        public PropertyListingRepository(ListingContext listingContext) : base(listingContext)
        {
        }

        public virtual async Task<IEnumerable<PropertyListing>> GetAllByPriceRangeAsync(PriceRange priceRange, int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;

            return await _context.Set<PropertyListing>()
                .Where(p => p.Price >= priceRange.MinPrice && p.Price <= priceRange.MaxPrice)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}

using DAL.DatabaseContext;
using Models.Listings;

namespace DAL
{
    public class PropertyListingRepository : BaseRepository<PropertyListing>, IPropertyListingRepository
    {
        public PropertyListingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
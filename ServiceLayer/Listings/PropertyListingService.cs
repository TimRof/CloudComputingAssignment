using Models.General;
using Models.Listings;

namespace ServiceLayer.Listings
{
    public class PropertyListingService : IListingService<PropertyListing>
    {
        private List<PropertyListing> _properties;

        public PropertyListingService()
        {
            if (_properties == null)
            {
                _properties = new List<PropertyListing>();
                Add(new PropertyListing
                {
                    Address = "TestAddress",
                    City = "TestCity",
                    Price = 1337,
                    Region = "TestRegion"
                });
                Console.WriteLine(_properties.ElementAt(0).Id);
            }
        }

        public void Add(PropertyListing listing)
        {
            _properties.Add(listing);
        }

        public PropertyListing Get(Guid id)
        {
            return _properties.FirstOrDefault(p => p?.Id == id);
        }

        public IEnumerable<PropertyListing> GetAll(int page = 1, int pageSize = 10)
        {
            int skip = (page - 1) * pageSize;

            return _properties.Skip(skip).Take(pageSize);
        }

        public IEnumerable<PropertyListing> GetAllByPriceRange(PriceRange priceRange, int page = 1, int pageSize = 10)
        {
            int skip = (page - 1) * pageSize;

            return _properties
                .Where(p => p.Price >= priceRange.MinPrice && p.Price <= priceRange.MaxPrice)
                .Skip(skip)
                .Take(pageSize);
        }
    }
}
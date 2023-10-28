namespace Entities.Models.General
{
    public class PriceRange
    {
        public PriceRange(decimal minPrice = 0, decimal maxPrice = 0)
        {
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
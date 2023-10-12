using DAL.DatabaseContext;
using Models.Offer;

namespace DAL
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {
        public OfferRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
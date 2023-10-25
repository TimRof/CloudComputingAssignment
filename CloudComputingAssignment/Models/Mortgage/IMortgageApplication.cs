using Entities.Models.Listing;
using Entities.Models.User;

namespace Entities.Models.Mortgage
{
    public interface IMortgageApplication : IEntityBase
    {
        public Guid ApplicantId { get; set; }

        public Guid ListingId { get; set; }

        public decimal MonthlyIncome { get; set; }

        public MortgageStatus Status { get; set; }

        public DateTime ApplicationSent { get; set; }
    }
}
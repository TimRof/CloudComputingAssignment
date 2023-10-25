using Entities.Models.Listing;
using Entities.Models.User;

namespace Entities.Models.Mortgage
{
    public class MortgageApplication : IMortgageApplication
    {
        public Guid Id { get; set; } = EntityBaseExtensions.GenerateId();
        public Guid ApplicantId { get; set; }
        public Guid ListingId { get; set; }
        public decimal MonthlyIncome { get; set; }
        public MortgageStatus Status { get; set; } = MortgageStatus.Processing;
        public DateTime ApplicationSent { get; set; } = DateTime.Now;
        public MortgageApplication() { }
    }
}
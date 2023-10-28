using Entities.Models.General;

namespace Entities.Models.Mortgage
{
    public interface IMortgageApplication : IEntityBase
    {
        public Guid ApplicantId { get; set; }

        public Guid ListingId { get; set; }

        public decimal MonthlyIncome { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }

        public DateTime ApplicationSent { get; set; }
    }
}
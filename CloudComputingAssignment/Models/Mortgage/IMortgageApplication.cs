using Entities.Models.Listing;
using Entities.Models.User;

namespace Entities.Models.Mortgage
{
    public interface IMortgageApplication : IEntityBase
    {
        public IUser Applicant { get; set; }

        public IListing Listing { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal LoanAmount { get; set; }

        public MortgageApplicationStatus Status { get; set; }

        public DateTime ApplicationSent { get; set; }
    }
}
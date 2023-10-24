using Entities.Models.Listing;
using Entities.Models.User;

namespace Entities.Models.Mortgage
{
    public enum MortgageApplicationStatus
    {
        Pending,
        Accepted,
        Rejected,
        Expired
    }
    public class MortgageApplication : IMortgageApplication
    {
        public Guid Id { get; set; } = EntityBaseExtensions.GenerateId();

        public IUser Applicant { get; set; }

        public IListing Listing { get; set; }

        public decimal MonthlyIncome { get; set; }

        public decimal LoanAmount { get; set; }

        public MortgageApplicationStatus Status { get; set; }

        public DateTime ApplicationSent { get; set; }

        public MortgageApplication()
        { }
    }
}
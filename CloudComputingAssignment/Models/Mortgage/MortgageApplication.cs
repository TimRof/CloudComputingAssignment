using Entities.Models.Listing;
using Entities.Models.User;

namespace Entities.Models.Mortgage
{
    public enum MortgageApplicationStatus
    {
        Processing,
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
        public MortgageApplicationStatus Status { get; set; } = MortgageApplicationStatus.Processing;
        public DateTime ApplicationSent { get; set; } = DateTime.Now;
        public MortgageApplication() { }
    }
}
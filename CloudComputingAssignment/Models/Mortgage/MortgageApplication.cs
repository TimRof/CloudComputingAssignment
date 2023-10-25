using Entities.Models.General;
using Entities.Models.Listing;
using Entities.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Mortgage
{
    public class MortgageApplication : IMortgageApplication
    {
        public Guid Id { get; set; } = EntityBaseExtensions.GenerateId();
        public Guid ApplicantId { get; set; }
        public Guid ListingId { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal MonthlyIncome { get; set; }

        [EnumDataType(typeof(ApplicationStatus))]
        public ApplicationStatus ApplicationStatus { get; set; } = ApplicationStatus.Processing;
        public DateTime ApplicationSent { get; set; } = DateTime.Now;
        public MortgageApplication() { }
    }
}
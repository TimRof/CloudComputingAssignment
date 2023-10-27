using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.General;

namespace Entities.Models.Mortgage
{
    public class MortgageOffer : IMortgageOffer
    {
        public Guid Id { get; set; } = EntityBaseExtensions.GenerateId();
        public Guid ApplicantId { get; set; }
        public string ApplicantEmail { get; set; }
        public Guid MortgageApplicationId { get; set; }
        public decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public DateTime ExpiryTime { get; set; }
        
        [EnumDataType(typeof(ApplicationStatus))]
        public ApplicationStatus OfferStatus { get; set; }

        public MortgageOffer() { }
    }
}

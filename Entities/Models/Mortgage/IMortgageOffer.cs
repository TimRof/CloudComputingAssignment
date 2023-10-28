using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.General;

namespace Entities.Models.Mortgage
{
    internal interface IMortgageOffer : IEntityBase
    {
        public Guid MortgageApplicationId { get; set; }
        public decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public DateTime ExpiryTime { get; set; }
        public ApplicationStatus OfferStatus { get; set; }
    }
}

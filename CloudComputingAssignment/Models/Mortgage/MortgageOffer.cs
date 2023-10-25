using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Mortgage
{
    public class MortgageOffer : IMortgageOffer
    {
        public Guid Id { get; set; } = EntityBaseExtensions.GenerateId();
        public MortgageApplication Application { get; set; }
        public decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public DateTime ExpiryTime { get; set; }
        public MortgageStatus Status { get; set; } = MortgageStatus.Pending;

        public MortgageOffer() { }
    }
}

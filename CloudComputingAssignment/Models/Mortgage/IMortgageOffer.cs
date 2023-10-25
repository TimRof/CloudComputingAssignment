using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Mortgage
{
    internal interface IMortgageOffer : IEntityBase
    {
        public MortgageApplication Application { get; set; }
        public decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public DateTime ExpiryTime { get; set; }
        public MortgageStatus Status { get; set; }
    }
}

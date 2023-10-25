using Entities.Models.Mortgage;
using Entities.Models.User;
using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mortgage
{
    public interface IMortgageRepository : IBaseRepository<MortgageContext, MortgageApplication>
    {
        public MortgageApplication GetApplicationByUserId(Guid userId);
        public void SetApplicationStatus(Guid userId, MortgageStatus status);
        public void AddMortgageOffer(MortgageOffer offer);
        public MortgageOffer GetMortgageOfferById(Guid id);
        public MortgageOffer GetMortgageOfferByApplicationId(Guid applicationId);
        public IEnumerable<MortgageOffer> GetMortgageOffersByUserId(Guid applicationId);
    }
}

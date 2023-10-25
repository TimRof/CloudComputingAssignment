using Entities.Models.Mortgage;
using Entities.Models.User;
using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mortgage
{
    public class MortgageRepository : BaseRepository<MortgageContext, MortgageApplication>, IMortgageRepository
    {
        public MortgageRepository(MortgageContext mortgageContext) : base(mortgageContext)
        {
            
        }

        public void AddMortgageOffer(MortgageOffer offer)
        {
            _context.MortgageOffers.Add(offer);
        }

        public MortgageApplication GetApplicationByUserId(Guid userId)
        {
            return _context.MortgageApplications.FirstOrDefault(app => app.ApplicantId == userId);
        }

        public MortgageOffer GetMortgageOfferByApplicationId(Guid applicationId)
        {
            return _context.MortgageOffers.FirstOrDefault(offer => offer.Application.Id == applicationId);
        }

        public MortgageOffer GetMortgageOfferById(Guid token)
        {
            return _context.MortgageOffers.FirstOrDefault(offer => offer.Id == token);
        }

        public IEnumerable<MortgageOffer> GetMortgageOffersByUserId(Guid applicationId)
        {
            return _context.MortgageOffers.Where(offer => offer.Application.ApplicantId == applicationId).AsEnumerable();
        }

        public void SetApplicationStatus(Guid id, MortgageStatus status)
        {
            _context.MortgageApplications.FirstOrDefault(app => app.Id == id).Status = status;
        }
    }
}

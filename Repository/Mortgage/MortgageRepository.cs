using Entities.Models.General;
using Entities.Models.Mortgage;
using Entities.Models.User;
using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Repository.Mortgage
{
    public class MortgageRepository : BaseRepository<MortgageContext, MortgageApplication>, IMortgageRepository
    {
        public MortgageRepository(MortgageContext mortgageContext) : base(mortgageContext)
        {
        }

        public async Task AddMortgageOfferAsync(MortgageOffer offer)
        {
            _context.MortgageOffers.Add(offer);
        }

        public async Task<MortgageApplication> GetApplicationByUserIdAsync(Guid userId)
        {
            return await Task.FromResult(_context.MortgageApplications.FirstOrDefault(app => app.ApplicantId == userId));
        }

        public async Task<MortgageOffer> GetMortgageOfferByApplicationIdAsync(Guid applicationId)
        {
            return await Task.FromResult(_context.MortgageOffers.FirstOrDefault(offer => offer.MortgageApplicationId == applicationId));
        }

        public async Task<MortgageOffer> GetMortgageOfferByIdAsync(Guid token)
        {
            return await Task.FromResult(_context.MortgageOffers.FirstOrDefault(offer => offer.Id == token));
        }

        public async Task<IEnumerable<MortgageOffer>> GetMortgageOffersByUserIdAsync(Guid userId)
        {
            var application = await GetApplicationByUserIdAsync(userId);
            return _context.MortgageOffers.Where(offer => offer.MortgageApplicationId == application.Id).AsEnumerable();
        }

        public async Task SetApplicationStatusAsync(Guid id, ApplicationStatus status)
        {
            var application = _context.MortgageApplications.FirstOrDefault(app => app.Id == id);
            if (application != null)
            {
                application.ApplicationStatus = status;
            }
        }

        public async Task<IEnumerable<MortgageOffer>> GetAllMortgageOffersWithStatusReadyToSendAsync()
        {
            return await Task.FromResult(_context.MortgageOffers.Where(app => app.OfferStatus == ApplicationStatus.ReadyToSend).AsEnumerable());
        }

        public async Task SetMortgageOfferStatusAsync(ApplicationStatus status, Guid id)
        {
            var application = _context.MortgageOffers.FirstOrDefault(app => app.Id == id);
            if (application != null)
            {
                application.OfferStatus = status;
            }
        }

        public async Task<IEnumerable<MortgageApplication>> GetAllMortgageApplicationsWithStatusProcessingAsync()
        {
            return await Task.FromResult(_context.MortgageApplications.Where(app => app.ApplicationStatus == ApplicationStatus.Processing).AsEnumerable());
        }
    }
}

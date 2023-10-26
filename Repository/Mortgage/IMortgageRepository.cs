using Entities.Models.General;
using Entities.Models.Mortgage;
using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Mortgage
{
    public interface IMortgageRepository : IBaseRepository<MortgageContext, MortgageApplication>
    {
        Task<MortgageApplication> GetApplicationByUserIdAsync(Guid userId);
        Task SetApplicationStatusAsync(Guid userId, ApplicationStatus status);
        Task AddMortgageOfferAsync(MortgageOffer offer);
        Task<MortgageOffer> GetMortgageOfferByIdAsync(Guid id);
        Task<MortgageOffer> GetMortgageOfferByApplicationIdAsync(Guid applicationId);
        Task<IEnumerable<MortgageOffer>> GetMortgageOffersByUserIdAsync(Guid userId);
    }
}

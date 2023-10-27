using Entities.Models.General;
using Entities.Models.Mortgage;

namespace ServiceLayer.Mortgage
{
    public interface IMortgageOfferService<T> : IBaseService<T> where T : MortgageOffer
    {
        Task SetMortgageOfferStatusAsync(ApplicationStatus status, Guid id);
        Task<IEnumerable<MortgageOffer>> GetAllMortgageOffersWithStatusReadyToSendAsync();

        Task CalculateAndMakeMortgageOffers(IEnumerable<MortgageApplication> applications);
    }
}

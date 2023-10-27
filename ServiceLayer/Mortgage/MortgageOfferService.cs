using Entities.Models.General;
using Entities.Models.Mortgage;
using Repository.Mortgage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Mortgage
{
    public class MortgageOfferService : IMortgageOfferService<MortgageOffer>
    {
        private readonly IMortgageRepository _repository;

        public MortgageOfferService(IMortgageRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(MortgageOffer entity)
        {
            await _repository.AddMortgageOfferAsync(entity);
            await _repository.CommitAsync();
        }

        public async Task SetMortgageOfferStatusAsync(ApplicationStatus status, Guid id)
        {
            await _repository.SetMortgageOfferStatusAsync(status, id);
            await _repository.CommitAsync();
        }

        public async Task<MortgageOffer> GetMortgageOfferByApplicationIdAsync(Guid id)
        {
            return await _repository.GetMortgageOfferByApplicationIdAsync(id);
        }

        public async Task<IEnumerable<MortgageOffer>> GetMortgageOffersByUserIdAsync(Guid id)
        {
            return await _repository.GetMortgageOffersByUserIdAsync(id);
        }

        public async Task<MortgageOffer> GetAsync(Guid id)
        {
            return await _repository.GetMortgageOfferByIdAsync(id);
        }

        public Task<IEnumerable<MortgageOffer>> GetAllAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MortgageOffer>> GetAllMortgageOffersWithStatusReadyToSendAsync()
        {
           return await _repository.GetAllMortgageOffersWithStatusReadyToSendAsync();
        }

        public async Task CalculateAndMakeMortgageOffers(IEnumerable<MortgageApplication> applications)
        {
            foreach (var application in applications)
            {
                // Calculate mortgage offer based on income
                var (amount, interestRate) = CalculateMortgageOffer(application.MonthlyIncome*12);

                // Make mortgage offer and add to database
                await _repository.AddMortgageOfferAsync(new MortgageOffer
                {
                    ApplicantId = application.ApplicantId,
                    ApplicantEmail = application.ApplicantEmail,
                    MortgageApplicationId = application.Id,
                    LoanAmount = amount,
                    InterestRate = interestRate,
                    ExpiryTime = DateTime.Now.AddDays(7),
                    OfferStatus = ApplicationStatus.ReadyToSend
                });

                await _repository.CommitAsync();
            }
        }
        private static (decimal, double) CalculateMortgageOffer(decimal income)
        {
            return (income * 0.4m, 0.05);
        }
    }
}

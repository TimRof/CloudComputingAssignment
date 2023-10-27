using Entities.Models.General;
using Entities.Models.Mortgage;
using Repository.Mortgage;
using ServiceLayer.Email;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Mortgage
{
    public class MortgageOfferService : IMortgageOfferService<MortgageOffer>
    {
        private readonly IMortgageRepository _repository;
        private readonly IEmailService _emailService;

        public MortgageOfferService(IMortgageRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
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

        public async Task StartMorningMortgageProcessing()
        {
            // Get all mortgage offers with status Processing
            var mortgageOffers = await _repository.GetAllMortgageOffersWithStatusReadyToSendAsync();

            foreach (var offer in mortgageOffers)
            {
                // Send email to each user with the mortgage offer
                _emailService.SendMortgageOfferEmail(offer.ApplicantEmail, offer.Id); // Add check if email was sent successfully

                // Update mortgage offer status to PendingAcceptance
                await _repository.SetMortgageOfferStatusAsync(ApplicationStatus.PendingAcceptance, offer.Id);
                await _repository.CommitAsync();
            }
        }
    }
}

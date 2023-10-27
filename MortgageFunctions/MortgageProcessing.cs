using System;
using Entities.Models.General;
using Entities.Models.Mortgage;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ServiceLayer.Email;
using ServiceLayer.Mortgage;

namespace MortgageFunctions
{
    public class MortgageProcessing
    {
        private readonly IMortgageApplicationService<MortgageApplication> _mortgageApplicationService;
        private readonly IMortgageOfferService<MortgageOffer> _mortgageOfferService;
        private readonly IEmailService _emailService;

        public MortgageProcessing(IMortgageApplicationService<MortgageApplication> mortgageApplicationService, IMortgageOfferService<MortgageOffer> mortgageOfferService, IEmailService emailService)
        {
            _mortgageApplicationService = mortgageApplicationService ?? throw new ArgumentNullException(nameof(mortgageApplicationService));
            _mortgageOfferService = mortgageOfferService ?? throw new ArgumentNullException(nameof(mortgageOfferService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        [FunctionName("DailyMortgageProcessing")]
        public void Run([TimerTrigger("59 23 * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                log.LogInformation($"Starting end of day mortgage applications processing at: {DateTime.Now}.");

                // Get all mortgage applications with Processing status
                var mortgageApplications = _mortgageApplicationService.GetAllMortgageApplicationsWithStatusProcessingAsync().Result;

                // Make Mortgage offer for each application
                _mortgageOfferService.CalculateAndMakeMortgageOffers(mortgageApplications);

                log.LogInformation($"End of day mortgage applications processing has ended at: {DateTime.Now}.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occurred while processing the mortgage applications.");
            }
        }

        [FunctionName("MorningEmailOffers")]
        public void RunMorningEmailOffers([TimerTrigger("0 6 * * *")] TimerInfo myTimer, ILogger log)
        {
            try
            {
                log.LogInformation($"Sending morning email mortgage offers at: {DateTime.Now}.");

                // Get all mortgage offers with status Processing
                var mortgageOffers = _mortgageOfferService.GetAllMortgageOffersWithStatusReadyToSendAsync().Result;

                foreach (var offer in mortgageOffers)
                {
                    // Send email to each user with the mortgage offer
                    _emailService.SendMortgageOfferEmail(offer.ApplicantEmail, offer.Id);
                    
                    // Update mortgage offer status to PendingAcceptance
                    _mortgageOfferService.SetMortgageOfferStatusAsync(ApplicationStatus.PendingAcceptance, offer.Id);
                }

                log.LogInformation($"Morning email mortgage offers done sending at: {DateTime.Now}.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occurred while sending morning email mortgage offers.");
            }
        }
    }
}

using System;
using Entities.Models.Mortgage;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ServiceLayer.Mortgage;

namespace MortgageFunctions
{
    public class MortgageProcessing
    {
        private readonly IMortgageApplicationService<MortgageApplication> _mortgageApplicationService;
        private readonly IMortgageOfferService<MortgageOffer> _mortgageOfferService;

        public MortgageProcessing(IMortgageApplicationService<MortgageApplication> mortgageApplicationService, IMortgageOfferService<MortgageOffer> mortgageOfferService)
        {
            _mortgageApplicationService = mortgageApplicationService ?? throw new ArgumentNullException(nameof(mortgageApplicationService));
            _mortgageOfferService = mortgageOfferService ?? throw new ArgumentNullException(nameof(mortgageOfferService));
        }

        [FunctionName("DailyMortgageProcessing")]
        public void Run([TimerTrigger("59 23 * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                log.LogInformation($"Starting end of day mortgage applications processing at: {DateTime.Now}.");

                // Get all mortgage applications with Processing status
                // Calculate Mortgage offer for each application
                // Save mortgage offer to database
                // Update mortgage application status to Processed

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
                // Send email to each user with the mortgage offer
                // Update mortgage offer status to PendingAcceptance

                log.LogInformation($"Morning email mortgage offers done sending at: {DateTime.Now}.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occurred while sending morning email mortgage offers.");
            }
        }
    }
}

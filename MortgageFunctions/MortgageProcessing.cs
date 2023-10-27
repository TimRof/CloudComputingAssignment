using System;
using System.Net.Http;
using System.Text;
using Entities.Models.General;
using Entities.Models.Mortgage;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceLayer.Email;
using ServiceLayer.Mortgage;
using static System.Net.Mime.MediaTypeNames;

namespace MortgageFunctions
{
    public class MortgageProcessing
    {
        // Replace with the actual URL or get from elsewhere
        private string _apiBaseUrl = "https://localhost:7166/api/Mortgage";

        private readonly ILogger _logger;

        public MortgageProcessing(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MortgageProcessing>();
        }

        [Function("Test")]
        public void Test([TimerTrigger("* * * * *")] TimerInfo myTimer, ILogger log)
        {
            _logger.LogInformation($"Test: {DateTime.Now}.");
            Test2();
            _logger.LogInformation($"Test: {DateTime.Now}.");
        }

        [Function("DailyMortgageProcessing")]
        public void RunDailyMortgageProcessing([TimerTrigger("59 23 * * *")] TimerInfo myTimer)
        {
            try
            {
                this._logger.LogInformation($"Starting end of day mortgage applications processing at: {DateTime.Now}.");

                // Get all mortgage applications with Processing status
                var mortgageApplications = GetApplicationsForProcessingViaAPICall().Result;

                if (mortgageApplications.Any())
                {
                    // Make Mortgage offer for each application
                    CalculateAndMakeMortgageOffersAPICall(mortgageApplications);
                }

                this._logger.LogInformation($"End of day mortgage applications processing has ended at: {DateTime.Now}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the mortgage applications.");
            }
        }

        [Function("MorningEmailOffers")]
        public async Task RunMorningEmailOffers([TimerTrigger("0 6 * * *")] TimerInfo myTimer)
        {
            try
            {
                _logger.LogInformation($"Sending morning email mortgage offers at: {DateTime.Now}.");

                // Get all mortgage offers with status Processing
                await StartMorningMortgageProcessing();

                _logger.LogInformation($"Morning email mortgage offers done sending at: {DateTime.Now}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending morning email mortgage offers.");
            }
        }

        private async Task CalculateAndMakeMortgageOffersAPICall(IEnumerable<MortgageApplication> applications)
        {
            await MakeApiPostRequest("CalculateAndMakeMortgageOffers", applications);
        }

        private async Task<IEnumerable<MortgageApplication>> GetApplicationsForProcessingViaAPICall()
        {
            return await GetApiResponse<MortgageApplication>("StatusProcessing");
        }

        private async Task StartMorningMortgageProcessing()
        {
            await GetApiResponse<MortgageOffer>("StartMorningMortgageProcessing");
        }
        private async Task Test2()
        {
            await GetApiResponse<MortgageOffer>("Test");
        }

        private async Task MakeApiPostRequest<T>(string endpoint, T contentObject)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Serialize the contentObject to JSON
                    string jsonContent = JsonConvert.SerializeObject(contentObject);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Send POST request to API endpoint
                    HttpResponseMessage response = await httpClient.PostAsync($"{_apiBaseUrl}/{endpoint}", httpContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"API call failed: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"An error occurred while making the API call: {ex.Message}");
                }
            }
        }
        private async Task<IEnumerable<T>> GetApiResponse<T>(string endpoint)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Send an HTTP GET request to the API endpoint
                    HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/{endpoint}");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<T>>(content);
                        return result;
                    }
                    else
                    {
                        _logger.LogError($"API call failed: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"An error occurred while making the API call: {ex.Message}");
                }

                // Return an empty list if there's an error
                return Enumerable.Empty<T>().ToList();
            }
        }
    }
}

using Entities.Models.General;
using Entities.Models.Mortgage;

namespace ServiceLayer.Mortgage
{
    public interface IMortgageApplicationService<T> : IBaseService<T> where T : MortgageApplication
    {
        public Task<MortgageApplication> GetApplicationByUserIdAsync(Guid userId);
        public Task SetApplicationStatusAsync(Guid id, ApplicationStatus status);

        public Task<IEnumerable<MortgageApplication>> GetAllMortgageApplicationsWithStatusProcessingAsync();
    }
}

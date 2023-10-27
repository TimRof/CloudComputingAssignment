using Entities.Models.General;
using Entities.Models.Mortgage;
using Repository.Mortgage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Mortgage
{
    public class MortgageApplicationService : IMortgageApplicationService<MortgageApplication>
    {
        private readonly IMortgageRepository _repository;

        public MortgageApplicationService(IMortgageRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(MortgageApplication application)
        {
            await _repository.AddAsync(application);
            await _repository.CommitAsync();
        }

        public async Task<MortgageApplication> GetAsync(Guid id)
        {
            return await _repository.GetSingleAsync(id);
        }

        public async Task<IEnumerable<MortgageApplication>> GetAllAsync(int page, int pageSize)
        {
            return await _repository.GetAllAsync(page, pageSize);
        }

        public async Task<MortgageApplication> GetApplicationByUserIdAsync(Guid userId)
        {
            return await _repository.GetApplicationByUserIdAsync(userId);
        }

        public async Task SetApplicationStatusAsync(Guid id, ApplicationStatus status)
        {
            await _repository.SetApplicationStatusAsync(id, status);
            await _repository.CommitAsync();
        }

        public async Task<IEnumerable<MortgageApplication>> GetAllMortgageApplicationsWithStatusProcessingAsync()
        {
            return await _repository.GetAllMortgageApplicationsWithStatusProcessingAsync();
        }
    }
}

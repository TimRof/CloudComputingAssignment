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
    }
}

using Entities.Models.Mortgage;
using Repository.Mortgage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Add(MortgageOffer entity)
        {
            _repository.AddMortgageOffer(entity);
        }

        public MortgageOffer GetMortgageOfferByApplicationId(Guid id)
        {
            return _repository.GetMortgageOfferByApplicationId(id);
        }

        public MortgageOffer GetMortgageOfferByUserId(Guid id)
        {
            return _repository.GetMortgageOfferByUserId(id);
        }

        public MortgageOffer Get(Guid id)
        {
           return _repository.GetMortgageOfferById(id);
        }

        public IEnumerable<MortgageOffer> GetAll(int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}

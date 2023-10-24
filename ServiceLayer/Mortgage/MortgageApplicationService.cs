using Entities.Models.Mortgage;
using Repository.Mortgage;

namespace ServiceLayer.Mortgage
{
    public class MortgageApplicationService : IMortgageApplicationService<MortgageApplication>
    {
        private readonly IMortgageApplicationRepository _repository;

        public MortgageApplicationService(IMortgageApplicationRepository repository)
        {
            _repository = repository;
        }

        public void Add(MortgageApplication application)
        {
            _repository.Add(application);
            _repository.Commit();
        }

        public MortgageApplication Get(Guid id)
        {
            return _repository.GetSingle(id);
        }

        public IEnumerable<MortgageApplication> GetAll(int page, int pageSize)
        {
            return _repository.GetAll(page, pageSize);
        }

        public MortgageApplication GetApplicationByUserId(Guid userId)
        {
            return _repository.GetApplicationByUserId(userId);
        }
        public void SetApplicationStatus(Guid id, MortgageApplicationStatus status)
        {
            _repository.SetApplicationStatus(id, status);
            _repository.Commit();
        }
    }
}

using Entities.Models.Mortgage;

namespace ServiceLayer.Mortgage
{
    public interface IMortgageApplicationService<T> : IBaseService<T> where T : MortgageApplication
    {
        public MortgageApplication GetApplicationByUserId(Guid userId);
        public void SetApplicationStatus(Guid id, MortgageApplicationStatus status);
    }
}

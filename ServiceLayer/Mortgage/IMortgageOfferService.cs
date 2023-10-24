using Entities.Models.Mortgage;

namespace ServiceLayer.Mortgage
{
    public interface IMortgageOfferService<T> : IBaseService<T> where T : MortgageOffer
    {
    }
}

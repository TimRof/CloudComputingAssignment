using Models.Users;

namespace ServiceLayer.Users
{
    public interface ICustomerService<T> : IBaseService<T> where T : Customer
    {
        void Add(decimal monthlyIncome);
    }
}
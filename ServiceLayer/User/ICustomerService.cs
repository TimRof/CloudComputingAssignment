using Entities.Models.User;

namespace ServiceLayer.User
{
    public interface ICustomerService<T> : IBaseService<T> where T : Customer
    {
    }
}
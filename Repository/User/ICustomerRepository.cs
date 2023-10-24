using Entities.Models.User;
using Repository.DatabaseContext;

namespace Repository
{
    public interface ICustomerRepository : IBaseRepository<UserContext, Customer>
    {
    }
}
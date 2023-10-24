using Repository.DatabaseContext;
using Entities;
using Entities.Models.User;

namespace Repository
{
    public class CustomerRepository : BaseRepository<UserContext, Customer>, ICustomerRepository
    {
        public CustomerRepository(UserContext userContext) : base(userContext)
        {
        }
    }
}
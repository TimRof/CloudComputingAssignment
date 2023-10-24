using Entities.Models.Mortgage;
using Entities.Models.User;
using Repository;

namespace ServiceLayer.User
{
    public class CustomerService : ICustomerService<Customer>
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void Add(Customer customer)
        {
            _repository.Add(customer);
            _repository.Commit();
        }

        public Customer Get(Guid id)
        {
            return _repository.GetSingle(id);
        }

        public IEnumerable<Customer> GetAll(int page, int pageSize)
        {
            return _repository.GetAll(page, pageSize);
        }
    }
}

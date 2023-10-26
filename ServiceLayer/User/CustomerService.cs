using Entities.Models.User;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.User
{
    public class CustomerService : ICustomerService<Customer>
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Customer customer)
        {
            _repository.AddAsync(customer);
            await _repository.CommitAsync();
        }

        public async Task<Customer> GetAsync(Guid id)
        {
            return await _repository.GetSingleAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(int page, int pageSize)
        {
            return await _repository.GetAllAsync(page, pageSize);
        }
    }
}

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IBaseService<T> where T : IEntityBase
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(int page, int pageSize);
        Task AddAsync(T entity);
    }
}

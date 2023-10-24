using Entities.Models;

namespace ServiceLayer
{
    public interface IBaseService<T> where T : IEntityBase
    {
        T Get(Guid id);

        IEnumerable<T> GetAll(int page, int pageSize);

        void Add(T entity);
    }
}
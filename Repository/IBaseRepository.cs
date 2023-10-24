using Entities.Models;
using System.Linq.Expressions;

namespace Repository
{
    public interface IBaseRepository<TContext, T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetAll(int page, int pageSize);

        int Count();

        T GetSingle(Guid id);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        void Commit();
    }
}
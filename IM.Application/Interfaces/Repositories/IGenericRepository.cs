using System.Linq.Expressions;

namespace IM.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes);
        Task<T> GetById(Guid id);
        Task Insert(T entity);
        void Update(Guid id, T entity); 
        Task Delete(Guid id);
        Task Save();
    }
}

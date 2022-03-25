using System.Linq.Expressions;

namespace IM.Application.Interfaces.Services
{
    public interface IGenericRepositoryService<T, U>
    {
        Task<IEnumerable<U>> GetAll();
        Task<IEnumerable<U>> GetAll(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<U>> GetAll(Expression<Func<T, object>>[] includes);
        Task<IEnumerable<U>> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes);
        Task<U> GetById(Guid id);
        Task Insert(U entityViewModel);
        Task Update(Guid id, U entityViewModel);
        Task Remove(Guid id);
    }
}

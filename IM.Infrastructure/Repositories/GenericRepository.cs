using IM.Application.Exceptions;
using IM.Application.Interfaces.Repositories;
using IM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IM.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, object>>[] includes)
        {
            try
            {
                var query = _context.Set<T>().AsQueryable();
                foreach (Expression<Func<T, object>> i in includes)
                {
                    query = query.Include(i);
                }
                return await query.ToListAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes)
        {
            try
            {
                var query = _context.Set<T>().Where(predicate);
                foreach (Expression<Func<T, object>> i in includes)
                {
                    query = query.Include(i);
                }
                return await query.ToListAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public virtual async Task<T> GetById(Guid id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            if(result == null) throw new Exception();

            try
            {
                return result;
            }
            catch
            {
                throw new Exception();
            }
        }

        public virtual async Task Insert(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch
            {
                throw new Exception();
            }
        }

        public virtual void Update(Guid Id, T entity)
        {
            try
            {
                //_context.Set<T>().Update(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch
            {
                throw new UpdateEntityFailedRepositorySaveException<T>();
            }
        }

        public virtual async Task Delete(Guid id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            if (result == null) throw new Exception(); //No Entity found

            try
            {
                _context.Set<T>().Remove(result);
            }
            catch
            {
                throw new Exception(); //Error on context remove entity
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

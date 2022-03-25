using AutoMapper;
using IM.Domain.Interfaces.ViewModel;
using IM.Domain.Interfaces.Entity;
using IM.Application.Interfaces.Repositories;
using IM.Application.Interfaces.Services;
using System.Linq.Expressions;

namespace IM.Application.Services
{
    public class GenericRepositoryService<T, U> : IGenericRepositoryService<T, U> where T : IBaseEntity where U : IBaseEntityViewModel
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;

        public GenericRepositoryService(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<U>> GetAll()
        {
            var result = await _repository.GetAll();
            return _mapper.Map<IEnumerable<U>>(result);
        }

        public virtual async Task<IEnumerable<U>> GetAll(Expression<Func<T, bool>> predicate)
        {
            var result = await _repository.GetAll(predicate);
            return _mapper.Map<IEnumerable<U>>(result);

        }
        public virtual async Task<IEnumerable<U>> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes)
        {
            var result = await _repository.GetAll(predicate, includes);
            return _mapper.Map<IEnumerable<U>>(result);
        }

        public virtual async Task<IEnumerable<U>> GetAll(Expression<Func<T, object>>[] includes)
        {
            var result = await _repository.GetAll(includes);
            return _mapper.Map<IEnumerable<U>>(result);
        }

        public virtual async Task<U> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            return _mapper.Map<U>(result);
        }

        public virtual async Task Insert(U entityViewModel)
        {
            var mapEntity = _mapper.Map<T>(entityViewModel);
            await _repository.Insert(mapEntity);
            await _repository.Save();
        }

        public virtual async Task Update(Guid id, U entityViewModel)
        {
            if (id != entityViewModel.Id) throw new NotImplementedException();

            var mapEntity = _mapper.Map<T>(entityViewModel);
            _repository.Update(id, mapEntity);
            await _repository.Save();
        }

        public virtual async Task Remove(Guid id)
        {
            await _repository.Delete(id);
            await _repository.Save();
        }
    }
}

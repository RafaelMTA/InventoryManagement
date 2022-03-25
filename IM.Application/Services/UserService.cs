using AutoMapper;
using IM.Application.Interfaces.Repositories;
using IM.Application.Interfaces.Services;
using IM.Application.ViewModels;
using IM.Domain.Entities;

namespace IM.Application.Services
{
    public class UserService : GenericRepositoryService<User, UserViewModel>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHash _hash;

        public UserService(IUserRepository repository, IMapper mapper, IPasswordHash hash) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _hash = hash;
        }

        public async Task<string> Login(string email, string password)
        {
            return await _repository.Login(email, password);
        }

        /// <summary>
        /// Overrided Insert Method from GenericRepositoryService, includes User data 
        /// </summary>
        /// <param name="auth">AuthViewModel </param>
        /// <returns></returns>
        public override async Task Insert(UserViewModel user)
        {
            var mapEntity = _mapper.Map<User>(user);
            mapEntity.UserDetails.FirstName = user.FirstName;
            mapEntity.UserDetails.LastName = user.LastName; 
            mapEntity.Password = _hash.Hash(user.Password);

            await _repository.Insert(mapEntity);
            await _repository.Save();
        }
    }
}

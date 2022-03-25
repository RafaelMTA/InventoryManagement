using IM.Application.ViewModels;
using IM.Domain.Entities;

namespace IM.Application.Interfaces.Services
{
    public interface IUserService : IGenericRepositoryService<User, UserViewModel>
    {
        public Task<string> Login(string email, string password);
    }
}

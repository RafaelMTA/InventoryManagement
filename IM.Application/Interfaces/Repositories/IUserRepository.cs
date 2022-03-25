using IM.Domain.Entities;

namespace IM.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<string> Login(string email, string password);
    }
}

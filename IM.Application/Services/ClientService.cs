using AutoMapper;
using IM.Application.Interfaces.Repositories;
using IM.Application.Interfaces.Services;
using IM.Application.ViewModels;
using IM.Domain.Entities;

namespace IM.Application.Services
{
    public class ClientService : GenericRepositoryService<Client, ClientViewModel>, IClientService
    {
        public ClientService(IGenericRepository<Client> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

using AutoMapper;
using IM.Application.Interfaces.Repositories;
using IM.Application.Interfaces.Services;
using IM.Application.ViewModels;
using IM.Domain.Entities;

namespace IM.Application.Services
{
    public class InventoryService : GenericRepositoryService<Inventory, InventoryViewModel>, IInventoryService
    {
        public InventoryService(IGenericRepository<Inventory> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

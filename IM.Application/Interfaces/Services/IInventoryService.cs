using IM.Application.ViewModels;
using IM.Domain.Entities;

namespace IM.Application.Interfaces.Services
{
    public interface IInventoryService : IGenericRepositoryService<Inventory, InventoryViewModel>
    {
    }
}

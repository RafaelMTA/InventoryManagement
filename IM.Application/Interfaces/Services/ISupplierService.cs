using IM.Application.ViewModels;
using IM.Domain.Entities;

namespace IM.Application.Interfaces.Services
{
    public interface ISupplierService : IGenericRepositoryService<Supplier, SupplierViewModel>
    {
    }
}

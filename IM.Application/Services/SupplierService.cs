using AutoMapper;
using IM.Application.Interfaces.Repositories;
using IM.Application.Interfaces.Services;
using IM.Application.ViewModels;
using IM.Domain.Entities;

namespace IM.Application.Services
{
    public class SupplierService : GenericRepositoryService<Supplier, SupplierViewModel>, ISupplierService
    {
        public SupplierService(IGenericRepository<Supplier> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

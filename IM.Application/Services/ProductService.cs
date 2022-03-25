using AutoMapper;
using IM.Application.ViewModels;
using IM.Application.Interfaces.Repositories;
using IM.Application.Interfaces.Services;
using IM.Domain.Entities;

namespace IM.Application.Services
{
    public class ProductService : GenericRepositoryService<Product, ProductViewModel>, IProductService
    {
        public ProductService(IGenericRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

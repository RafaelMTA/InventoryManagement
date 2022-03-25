using AutoMapper;
using IM.Application.ViewModels;
using IM.Application.Interfaces.Repositories;
using IM.Application.Interfaces.Services;
using IM.Domain.Entities;

namespace IM.Application.Services
{
    public class OrderService : GenericRepositoryService<Order, OrderViewModel>, IOrderService
    {
        public OrderService(IGenericRepository<Order> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

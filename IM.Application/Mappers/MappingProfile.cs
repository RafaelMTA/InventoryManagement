using IM.Application.ViewModels;
using IM.Domain.Entities;
using AutoMapper;

namespace IM.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Client, ClientViewModel>().ReverseMap();
            CreateMap<Inventory, InventoryViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();           
            CreateMap<Supplier, SupplierViewModel>().ReverseMap(); 
        }       
    }
}

using AutoMapper;
using Services.Order.Application.Dtos;

namespace Services.Order.Application.Mappings
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.Order, OrderDto>().ReverseMap();
            CreateMap<Domain.OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Domain.Address, AddressDto>().ReverseMap();
        }
    }
}
using AutoMapper;
using OrderManagement.Domain;

namespace OrderManagement.Api.Dtos.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
        }
    }
}

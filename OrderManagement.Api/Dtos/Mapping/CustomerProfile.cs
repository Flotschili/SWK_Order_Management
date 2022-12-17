using AutoMapper;
using OrderManagement.Domain;

namespace OrderManagement.Api.Dtos.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            //.ForMember(dst => dst.ZipCode, opt => opt.MapFrom(src => 4193));

            CreateMap<CustomerDto, Customer>();

            CreateMap<CustomerForUpdateDto, Customer>();
        }
    }
}

//using OrderManagement.Domain;

//namespace OrderManagement.Api.Dtos
//{
//    public static class DtoExtensions
//    {
//        public static CustomerDto ToDto(this Customer customer) =>
//            new()
//            {
//                Id = customer.Id,
//                City = customer.City,
//                Name = customer.Name,
//                Rating = customer.Rating,
//                ZipCode = customer.ZipCode
//            };

//        public static OrderDto ToDto(this Order order) =>
//            new()
//            {
//                Id = order.Id,
//                Article = order.Article,
//                OrderDate = order.OrderDate,
//                TotalPrice = order.TotalPrice
//            };

//        public static Customer ToDomain(this CustomerDto customerDto) =>
//            new(customerDto.Id,
//                customerDto.Name,
//                customerDto.ZipCode,
//                customerDto.City,
//                customerDto.Rating
//                );
//    }
//}

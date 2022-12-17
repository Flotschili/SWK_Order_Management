using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Api.Dtos;
using OrderManagement.Logic;

namespace OrderManagement.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManagementLogic logic;
        private readonly IMapper mapper;

        public OrdersController(
            IOrderManagementLogic orderManagementLogic,
            IMapper mapper)
        {
            this.logic = orderManagementLogic ?? throw new ArgumentNullException(nameof(orderManagementLogic));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET /api/customers/{customerId}/orders
        [HttpGet("customers/{customerId}/orders")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersOfCustomer(
            Guid customerId)
        {
            if (!await logic.CustomerExists(customerId))
            {
                return NotFound();
            }

            var ordersOfCustomer = await logic.GetOrdersOfCustomer(customerId);
            return Ok(mapper.Map<IEnumerable<OrderDto>>(ordersOfCustomer));
        }
    }
}

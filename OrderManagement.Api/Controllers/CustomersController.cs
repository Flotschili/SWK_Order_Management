using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Api.Dtos;
using OrderManagement.Domain;
using OrderManagement.Logic;

namespace OrderManagement.Api.Controllers
{
    [ApiConventionType(typeof(WebApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IOrderManagementLogic logic;
        private readonly IMapper mapper;

        public CustomersController(
            IOrderManagementLogic logic,
            IMapper mapper)
        {
            this.logic = logic ?? throw new ArgumentNullException(nameof(logic));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET /api/customers
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetCustomers([FromQuery] Rating? rating)
        {
            if (rating.HasValue)
            {
                return mapper.Map<IEnumerable<CustomerDto>>(
                    (await logic.GetCustomersByRating(rating.Value)));
            }
            else
            {
                return mapper.Map<IEnumerable<CustomerDto>>(
                    (await logic.GetCustomers()));
            }
        }

        // GET /api/customers/<GUID>
        [HttpGet("{customerId}")]
        //[ProducesDefaultResponseType]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        // Responses werden schon allgemein in WebApiConventions definiert
        public async Task<ActionResult<CustomerDto>> GetCustomerById([FromRoute] Guid customerId)
        {
            var customer = await logic.GetCustomer(customerId);

            if (customer is null)
            {
                return NotFound(StatusInfo.InvalidCustomerId(customerId));
            }

            return mapper.Map<CustomerDto>(customer);
        }

        // POST //api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(
            [FromBody] CustomerDto customerDto)
        {
            if (customerDto.Id != Guid.Empty && await logic.CustomerExists(customerDto.Id))
            {
                return Conflict(StatusInfo.CustomerAlreadyExists(customerDto.Id));
            }

            Customer customer = mapper.Map<Customer>(customerDto);
            await logic.AddCustomer(customer);
            return CreatedAtAction(
                actionName: nameof(GetCustomerById),
                routeValues: new { customerId = customer.Id },
                value: mapper.Map<CustomerDto>(customer)
                );
        }

        // PUT /api/customers/<GUID>
        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomer(
            [FromRoute] Guid customerId,
            [FromBody]  CustomerForUpdateDto customerDto)
        {
            Customer? customer = await logic.GetCustomer(customerId);

            if (customer is null)
            {
                return NotFound();
            }

            mapper.Map(customerDto, customer);
            await logic.UpdateCustomer(customer);
            return NoContent();
        }

        // DELETE /api/customers/<GUID>
        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] Guid customerId)
        {
            //if (await logic.DeleteCustomer(customerId))
            //{
            //    return NoContent();
            //} else
            //{
            //    return NotFound();
            //}
            await logic.DeleteCustomer(customerId);
            return NoContent();
        }

        [HttpPost("{customerId}/update-totals")]
        public async Task<ActionResult> UpdateCustomerTotals(Guid customerId)
        {
            if (!await logic.CustomerExists(customerId))
            {
                return NotFound(StatusInfo.InvalidCustomerId(customerId));
            }

            await logic.UpdateTotalRevenue(customerId);
            return NoContent();
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Api.Controllers
{
    public static class StatusInfo
    {
        public static ProblemDetails InvalidCustomerId(Guid customerId) =>
            new ProblemDetails
            {
                Title = "Invalid customer ID",
                Detail = $"Customer with ID '{customerId}' does not exist"
            };

        // Customer already exists
        public static ProblemDetails CustomerAlreadyExists(Guid customerId) =>
            new ProblemDetails
            {
                Title = "Customer already exists",
                Detail = $"Customer with ID '{customerId}' already exists"
            };
    }
}

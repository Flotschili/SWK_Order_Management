using OrderManagement.Domain;

namespace OrderManagement.Api.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public string Article { get; set; } = null!;

        public DateTimeOffset OrderDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}


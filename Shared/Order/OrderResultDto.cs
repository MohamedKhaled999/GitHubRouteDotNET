using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Order
{
    public record OrderResultDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public ShippingAddressDto ShippingAddressDto { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

        public string PaymentStatus { get; set; }
        public decimal SubTotal { get; set; }
        public string DeliveryMethod { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public decimal Total { get; set; }


    }
}


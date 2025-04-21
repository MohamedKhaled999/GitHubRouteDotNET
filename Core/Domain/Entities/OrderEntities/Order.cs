using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntities
{
    public class Order
    {
        public string UserEmail { get; set; }

        public ShippingAddress ShippingAddress { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public OrderPaymentStatus PaymentStatus { get; set; }

        public int? DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }

        //subtotal = items * price
        public decimal SubTotal { get; set; }
        public string PaymentIntentId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

    }
}

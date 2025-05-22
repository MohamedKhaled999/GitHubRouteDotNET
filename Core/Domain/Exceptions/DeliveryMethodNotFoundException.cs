using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DeliveryMethodNotFoundException : NotFoundException
    {
      
        public DeliveryMethodNotFoundException(int deliveryMethodId): base($"DeliveryMethod with {deliveryMethodId}  Not Found !!")
        {
          
        }

      
    }

}

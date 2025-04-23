using Shared.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.Abstractions
{
    public interface IOrderService
    {

        public Task<OrderResultDto> GetOrderByIdAsync(Guid orderID);
        public Task<IEnumerable<OrderResultDto>> GetOrderByEmailAsync(string email);

        public Task<OrderResultDto> CreateOrderAsync(OrderRequest request , string email);
        public Task<IEnumerable<DeliveryMethodDto>> DeliveryMethodAsync();
    }
}

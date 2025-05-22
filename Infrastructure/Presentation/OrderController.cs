using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [Authorize]
    public class OrderController(IServiceManager serviceManager):ApiController
    {

        [HttpPost]
        public async Task<ActionResult<OrderResultDto>> CreateOrder(OrderRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
           var order =  await serviceManager.OrderService.CreateOrderAsync(request, email);
            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResultDto>>> GetOrders()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var orders = await serviceManager.OrderService.GetOrderByEmailAsync(email);
            return Ok(orders);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderResultDto>>> GetOrderById(Guid orderid)
        {
            var orders = await serviceManager.OrderService.GetOrderByIdAsync(orderid);
            return Ok(orders);
        }
        [AllowAnonymous]
        [HttpGet("deliverymethods")]
        public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDeliveryMethods()
        {
            var methods = await serviceManager.OrderService.DeliveryMethodAsync();
            return Ok(methods);
        }
    }
}

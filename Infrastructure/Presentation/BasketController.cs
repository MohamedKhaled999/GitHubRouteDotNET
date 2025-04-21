using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
   
    public class BasketController : ApiController
    {
        private readonly IServiceManager _serviceManager;

        public BasketController(IServiceManager serviceManager)
        {

            _serviceManager = serviceManager;


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasket(string id)
        {
            var basket = await _serviceManager.BasketService.GetBasket(id);

            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(BasketDTO basketDTO)
        {
            var basket = await _serviceManager.BasketService.UpdateBasket(basketDTO);

            return Ok(basket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            var IsDeleted = await _serviceManager.BasketService.DeleteBasket(id);
            var text = IsDeleted ? "" : "not";
            return Ok(new {Message=$"Basket with {id} is {text} Deleted " });
        }
    }
}

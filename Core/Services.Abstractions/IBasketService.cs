using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IBasketService
    {
        public Task<BasketDTO?> GetBasket(string id);
        public Task<BasketDTO?> UpdateBasket(BasketDTO basketDTO);

        public Task<bool> DeleteBasket(string id);


    }
}

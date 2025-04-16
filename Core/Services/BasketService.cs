using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class BasketService(IBasketRepository _basketRepository  , IMapper _mapper ) : IBasketService
    {
        public async Task<bool> DeleteBasket(string id)
        {
          return await _basketRepository.DeleteBasketAsync(id);
        }

        public async Task<BasketDTO?> GetBasket(string id)
        {
            var basket = await _basketRepository.GetCustomerBasketAsync(id);
            return basket is null ?
             throw new BasketNotFoundException(id)  :
             _mapper.Map<BasketDTO>(basket);
        } 

        public async Task<BasketDTO?> UpdateBasket(BasketDTO basketDTO)
        {
            var basket = _mapper.Map<CustomerBasket>(basketDTO);

            //= await _basketRepository.GetCustomerBasketAsync(id);
            var updatedBasket = await _basketRepository
                .UpdateBasketAsync(basket);
            return updatedBasket is null ? throw new Exception("We Can Not Update Basket")
                                : _mapper.Map<BasketDTO>(basket );
        }

    }
}

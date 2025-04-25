using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Services.Abstractions;
using Shared;
using Stripe;
using Product = Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.OrderEntities;

namespace Services
{
    public class PaymentService(IBasketRepository basketRepository , IUnitOfWork  unitOfWork,IMapper mapper ,IConfiguration configuration) : IPaymentService
    {
        public async Task<BasketDTO> CreateOrUpdatePaymentAsync(string basketId)
        {
            //StripeConfiguration
            StripeConfiguration.ApiKey = configuration.GetRequiredSection("StripeSetting")["Secretkey"];

         var basket =  await  basketRepository.GetCustomerBasketAsync(basketId)
                ?? throw new BasketNotFoundException(basketId);

            foreach (var item in basket.Items)
            {
                var Product = await unitOfWork.GetRepository<Product, int>()
                    .GetAsync(item.Id)?? throw new ProductNotFoundException(item.Id);

                item.Price =Product.Price;
            }

            if (!basket.DeliveryMethodId.HasValue)
                throw new Exception("No Delivery Method is Selected");

            var method = await unitOfWork.GetRepository<DeliveryMethod, int>()
                .GetAsync(basket.DeliveryMethodId.Value)
                ??throw new DeliveryMethodNotFoundException(basket.DeliveryMethodId.Value);

            basket.ShippingPrice = method.Price;

            var amount = (long)(basket.Items.Sum(I => I.Quantity * I.Price) + basket.ShippingPrice);
            amount *= 100;

            if (string.IsNullOrWhiteSpace(basket.PaymentIntentId))
            {
                //create 
               var CreateOptions = new PaymentIntentCreateOptions()
                { 
                    Amount = amount,
                    PaymentMethodTypes=new() { "card"}
                    ,Currency="USD"
                };

                var paymentIntent = await new PaymentIntentService().CreateAsync(CreateOptions);


                basket.PaymentIntentId = paymentIntent.Id;
                basket.ClientSecret = paymentIntent.ClientSecret;


            }
            else
            {
                //update

                var updateOptions = new PaymentIntentUpdateOptions()
                {
                    Amount = amount,
               
                };

              await new PaymentIntentService()
                    .UpdateAsync(basket.PaymentIntentId,updateOptions);

            }


           await basketRepository.UpdateBasketAsync(basket);



            return mapper.Map<BasketDTO>(basket);
        }
    }

}

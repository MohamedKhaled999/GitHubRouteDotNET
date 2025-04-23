using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.OrderEntities;
using Domain.Exceptions;
using Services.Abstractions;
using Services.Specifications;
using Shared.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService(IBasketRepository basketRepository , IUnitOfWork unitOfWork,IMapper mapper ) : IOrderService
    {
        public async Task<OrderResultDto> CreateOrderAsync(OrderRequest request, string email)
        {

            var basket = await basketRepository.GetCustomerBasketAsync(request.BasketId);
            if ( basket == null )  throw new BasketNotFoundException( request.BasketId );
            
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var product = await unitOfWork.GetRepository<Product, int>()
                    .GetAsync(item.Id) ?? throw new ProductNotFoundException(item.Id);
                orderItems.Add(CreateOrderItem(item, product));
            }

            DeliveryMethod deliveryMethod = await unitOfWork.GetRepository<DeliveryMethod,int>()
                .GetAsync(request.DeliveryMethodId)?? throw new DeliveryMethodNotFoundException(request.DeliveryMethodId) ;

            var subTotal = orderItems.Sum(i => i.Price * i.Quantity);
            var shipping = mapper.Map<ShippingAddress>(request.ShippingAddressDto);
            var order = new Order(email,shipping, orderItems, deliveryMethod, subTotal);

            await unitOfWork.GetRepository<Order,Guid>().AddAsync(order);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<OrderResultDto>(order);
        }

        private OrderItem CreateOrderItem(BasketItem item, Product product)
        {
            return new(new ProductInOrderItem(product.Id,product.Name,product.PictureUrl)
                ,item.Quantity,item.Price);
        }

        public async Task<IEnumerable<DeliveryMethodDto>> DeliveryMethodAsync()
        {
          var  methods  =  await unitOfWork.GetRepository<DeliveryMethod, int>()
                .GetAllAsync();
            return mapper.Map<IEnumerable<DeliveryMethodDto>>(methods);
        }

        public async Task<IEnumerable<OrderResultDto>> GetOrderByEmailAsync(string email)
        {
            var orders = await unitOfWork.GetRepository<Order, Guid>()
                .GetAllWithSpecificationAsync( new OrderSpecifications(email))
                ?? throw new OrderNotFoundException(email);


            return mapper.Map<IEnumerable<OrderResultDto>>(orders);
        }

        public async Task<OrderResultDto> GetOrderByIdAsync(Guid orderID)
        {
            var order = await unitOfWork.GetRepository<Order, Guid>()
                            .GetByIdSpecificationAsync(new OrderSpecifications(orderID))
                            ?? throw new OrderNotFoundException(orderID); ;


            return mapper.Map<OrderResultDto>(order);
        }

      
    }

    

}

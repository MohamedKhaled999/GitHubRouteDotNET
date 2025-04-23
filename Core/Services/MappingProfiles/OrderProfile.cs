using AutoMapper;
using Domain.Entities.OrderEntities;
using Shared.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAddress,ShippingAddressDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(O => O.ProductName, P => P.MapFrom(P => P.Product.ProductName))
                .ForMember(O => O.ProductId, P => P.MapFrom(P => P.Product.ProductId))
                .ForMember(O => O.PictureUrl, P => P.MapFrom(P => P.Product.PictureUrl))
                .ReverseMap();



            CreateMap<Order, OrderResultDto>()
                .ForMember(O => O.DeliveryMethod, M => M.MapFrom(R => R.DeliveryMethod.ShortName))
                .ForMember(O => O.PaymentStatus, M => M.MapFrom(R => R.PaymentStatus.ToString()))
                .ForMember(O => O.Total, M => M.MapFrom(R => R.SubTotal + R.DeliveryMethod.Price))
                .ForMember(O => O.Total, M => M.MapFrom(R => R.DeliveryMethod.ShortName));


            CreateMap<DeliveryMethod, DeliveryMethodDto>().ReverseMap();


        }
    }
}

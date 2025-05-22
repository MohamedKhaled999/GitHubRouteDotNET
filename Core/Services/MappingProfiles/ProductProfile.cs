using AutoMapper;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResultDTO>()
                .ForMember((PR) => PR.TypeName, op => op.MapFrom(P => P.ProductType.Name))
                .ForMember((PR) => PR.BrandName, op => op.MapFrom(P => P.ProductBrand.Name))
                .ForMember((PR) => PR.PictureUrl,op=> op.MapFrom<PictureUrlResolver>() );
                
            CreateMap<ProductBrand, BrandResultDTO>();
            CreateMap<ProductType, TypeResultDTO>();
        }
    }

}

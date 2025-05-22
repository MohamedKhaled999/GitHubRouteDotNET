using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Services.Abstractions;
using Services.Specifications;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class ProductService(IUnitOfWork unitOfWork,IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            return mapper.Map<IEnumerable<BrandResultDTO>>(brands);
        }

        public async Task<PaginatedResult<ProductResultDTO>> GetAllProductsAsync(ProductSpecificationParameters parameters)
        {
            //var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync();
            var products = await unitOfWork.GetRepository<Product, int>()
                                .GetAllWithSpecificationAsync(new ProductWithBrandAndProductSpecification(parameters));
            var productResultDTOs = mapper.Map<IEnumerable<ProductResultDTO>>(products);
            var productsCount = await unitOfWork.GetRepository<Product, int>().GetCountAsync(new ProductsCountSpecifications(parameters));
            return new PaginatedResult<ProductResultDTO>
            (
                PageIndex :parameters.PageIndex,
                PageSize : parameters.PageSize,
                Count : productsCount
                , Data : productResultDTOs
                )
            ;

        }

        public async Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync()
        {
            var types = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return mapper.Map<IEnumerable<TypeResultDTO>>(types);
        }

        public async Task<ProductResultDTO?> GetProductByIdAsync(int id)
        {
            //var product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);
            var product = await unitOfWork.GetRepository<Product, int>()
                .GetByIdSpecificationAsync(new ProductWithBrandAndProductSpecification(id));
            if (product == null)
                throw new ProductNotFoundException(id);

            return  mapper.Map<ProductResultDTO?>(product);
        }
    }
}

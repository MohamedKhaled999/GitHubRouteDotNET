using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
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

        public async Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync()
        {
            //var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync();
            var products = await unitOfWork.GetRepository<Product, int>()
                                .GetAllWithSpecificationAsync(new ProductWithBrandAndProductSpecification());
            return mapper.Map<IEnumerable<ProductResultDTO>>(products);
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
            return  mapper.Map<ProductResultDTO?>(product);
        }
    }
}

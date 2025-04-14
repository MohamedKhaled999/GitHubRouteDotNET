using Domain.Contracts;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndProductSpecification : Specifications<Product>
    {

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id"></param
        public ProductWithBrandAndProductSpecification(int id ):base(p=>p.Id==id)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }

        /// <summary>
        /// Get All Products
        /// </summary>
       
        public ProductWithBrandAndProductSpecification( ProductSpecificationParameters parameters) 
            : base(P=>
                      (!parameters.BrandId.HasValue ||  P.BrandId == parameters.BrandId) &&
                      (!parameters.BrandId.HasValue ||  P.TypeId == parameters.TypeId  )
            &&
                      (
                        string.IsNullOrEmpty(parameters.Search)
                        ||
                        P.Name.ToLower().Contains(parameters.Search.ToLower().Trim())
                      )
            )
        {
            
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
            ApplyPagination(parameters.PageIndex,parameters.PageSize);
        }


    }
}

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
    public class ProductsCountSpecifications: Specifications<Product>
    {
        public ProductsCountSpecifications(ProductSpecificationParameters parameters)
            : base(P =>
                      (!parameters.BrandId.HasValue || P.BrandId == parameters.BrandId) &&
                      (!parameters.BrandId.HasValue || P.TypeId == parameters.TypeId)
            &&          (string.IsNullOrEmpty(parameters.Search) || P.Name.ToLower().Contains(parameters.Search.ToLower()) )
                  )
        {

        }
    }
}

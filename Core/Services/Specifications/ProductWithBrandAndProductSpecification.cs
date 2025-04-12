using Domain.Contracts;
using Domain.Entities;
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
        /// GetAllProduct
        /// </summary>
       
        public ProductWithBrandAndProductSpecification() : base(null)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductSpecificationParameters
    {
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public ProductSpecificationSort? Sort { get; set; }
    }

    public enum ProductSpecificationSort
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc,

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductSpecificationParameters
    {
        private const int MaximumPageSize = 10;
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public ProductSpecificationSort? Sort { get; set; }

        public int PageIndex { get; set; } = 1;

        private int _pageSize=5;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaximumPageSize ? MaximumPageSize : value; }
        } 
        public string? Search {  get; set; }


    }

    public enum ProductSpecificationSort
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc,

    }
}

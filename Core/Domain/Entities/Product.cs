using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product: BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        #region ProductBrand
        [ForeignKey("ProductBrand")]
        public int? BrandId { get; set; }
        public ProductBrand? ProductBrand { get; set; }
        #endregion

        #region ProductType
        [ForeignKey("ProductType")]
        public int? TypeId { get; set; }
        public ProductType? ProductType { get; set; }
        #endregion

    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            #region Product
            builder.Property(Product => Product.Price)
                .HasColumnType("decimal(18,3)");
            #endregion

            #region ProductType
            builder.HasOne(Product => Product.ProductType).
                WithMany()
                .HasForeignKey(Product => Product.TypeId)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region ProductBrand
            builder.HasOne(Product => Product.ProductBrand).
               WithMany()
               .HasForeignKey(Product => Product.BrandId)
               .OnDelete(DeleteBehavior.SetNull);
            #endregion
        }
    }
}

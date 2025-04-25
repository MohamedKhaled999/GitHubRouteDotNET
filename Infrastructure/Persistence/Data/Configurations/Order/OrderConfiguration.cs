using Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore;
using MyOrder = Domain.Entities.OrderEntities ;

namespace Persistence.Data.Configurations.Order;

internal class OrderConfiguration : IEntityTypeConfiguration<MyOrder.Order>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MyOrder.Order> builder)
    {
        builder.OwnsOne(O => O.ShippingAddress);
        builder.HasMany(O=>O.OrderItems);
        builder.Property(P => P.PaymentStatus).HasConversion(
            S => S.ToString(), S => Enum.Parse<OrderPaymentStatus>(S));

        builder.HasOne(O => O.DeliveryMethod).WithMany()
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(O => O.SubTotal)
            .HasColumnType("decimal(18,3)");

        builder
            .HasMany(o => o.OrderItems)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

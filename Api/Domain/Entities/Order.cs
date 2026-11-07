using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Entities;

public sealed class Order : AuditableEntity
{
    public Guid BuyerId { get; set; }
    public List<ProductItem> Products { get; set; }
    public decimal TotalPrice { get; set; }

    public User Buyer { get; set; }
}

public sealed record ProductItem(Guid Id, decimal Price, int Quantity, decimal SubTotal);

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.TotalPrice).HasPrecision(18, 2);
        builder.HasOne(o => o.Buyer)
            .WithMany()
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.OwnsMany(o => o.Products, p =>
        {
            p.ToJson();
            p.Property(x => x.Price).HasPrecision(18, 2);
            p.Property(x => x.SubTotal).HasPrecision(18, 2);
        });
    }
}

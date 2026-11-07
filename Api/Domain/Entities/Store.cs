using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Entities;

public sealed class Store : AuditableEntity
{
    public string Name { get; set; } = null!;
    public Guid SellerId { get; set; }

    public User Seller { get; set; }
}

internal sealed class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(150);
        builder.HasOne(s => s.Seller)
            .WithMany()
            .HasForeignKey(s => s.SellerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

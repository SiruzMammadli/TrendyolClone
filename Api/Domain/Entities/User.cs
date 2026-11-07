using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Entities;

public sealed class User : AuditableEntity
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public UserRole Role { get; set; } = UserRole.Buyer;
}

public enum UserRole : byte
{
    Buyer = 1,
    Seller = 2,
    Admin = 3
}

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(512);
        builder.Property(u => u.Fullname).IsRequired().HasMaxLength(150);
        builder.Property(u => u.Role).HasConversion<byte>();
        builder.HasIndex(u => u.Email).IsUnique();
    }
}

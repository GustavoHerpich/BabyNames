using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BabyName.Entities;

namespace BabyName.Data.Map;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.Username).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.PasswordExpiration).IsRequired();
        builder.Property(e => e.Role).IsRequired().HasConversion<string>().HasMaxLength(20);
    }
}
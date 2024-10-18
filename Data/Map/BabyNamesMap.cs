using BabyName.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BabyName.Data.Map;

public class BabyNamesMap : IEntityTypeConfiguration<BabyNames>
{
    public void Configure(EntityTypeBuilder<BabyNames> builder)
    {
        builder.ToTable("baby_names");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("id");
        builder.Property(b => b.Year).HasColumnName("year").IsRequired();
        builder.Property(b => b.Name).HasColumnName("name").HasMaxLength(12).IsRequired();
        builder.Property(b => b.Gender).HasColumnName("gender").HasMaxLength(1).IsRequired();
        builder.Property(b => b.Births).HasColumnName("births").IsRequired();
        builder.Property(b => b.Position).HasColumnName("pos").IsRequired();
    }
}

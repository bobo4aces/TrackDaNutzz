namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class VariantEntityTypeConfiguration : IEntityTypeConfiguration<Variant>
    {

        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            builder.ToTable("Variants");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(v => v.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(v => v.Type)
                .HasColumnName("Type")
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(v => v.Limit)
                .HasColumnName("Limit")
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(v => v.HasAnte)
                .HasColumnName("HasAnte")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);

            builder
                .HasMany(v => v.Tables)
                .WithOne(v => v.Variant)
                .HasForeignKey(v => v.VariantId);
        }
    }
}
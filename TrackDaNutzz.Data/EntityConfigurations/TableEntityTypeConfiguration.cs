namespace TrackDaNutzz.Data.EntityConfigurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class TableEntityTypeConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("Tables");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(t => t.ClientId)
                .HasColumnName("ClientId")
                .HasColumnType("INT")
                .IsRequired(true);

            builder.Property(t => t.Size)
                .HasColumnName("Size")
                .HasColumnType("TINYINT")
                .IsRequired(true);

            builder.Property(t => t.VariantId)
                .HasColumnName("VariantId")
                .HasColumnType("INT")
                .IsRequired(true);

            builder.Property(t => t.StakeId)
                .HasColumnName("StakeId")
                .HasColumnType("INT")
                .IsRequired(true);

            builder
                .HasOne(t => t.Client)
                .WithMany(t => t.Tables)
                .HasForeignKey(t => t.ClientId);

            builder
                .HasOne(t => t.Variant)
                .WithMany(t => t.Tables)
                .HasForeignKey(t => t.VariantId);

            builder
                .HasOne(t => t.Stake)
                .WithMany(t => t.Tables)
                .HasForeignKey(t => t.StakeId);

            builder
                .HasMany(t => t.Hands)
                .WithOne(t => t.Table)
                .HasForeignKey(t => t.TableId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
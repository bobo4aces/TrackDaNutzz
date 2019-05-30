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

            builder.Property(t => t.Client)
                .HasColumnName("Client")
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(t => t.Size)
                .HasColumnName("Size")
                .HasColumnType("VARCHAR(6)")
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(t => t.Currency)
                .HasColumnName("Currency")
                .HasColumnType("VARCHAR(10)")
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(t => t.Format)
                .HasColumnName("Format")
                .HasColumnType("VARCHAR(7)")
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(t => t.Limit)
                .HasColumnName("Limit")
                .HasColumnType("VARCHAR(10)")
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(t => t.SmallBlind)
                .HasColumnName("SmallBlind")
                .HasColumnType("MONEY")
                .IsRequired(true);

            builder.Property(t => t.BigBlind)
                .HasColumnName("BigBlind")
                .HasColumnType("MONEY")
                .IsRequired(true);

            builder
                .HasMany(t=>t.Hands)
                .WithOne(t=>t.Table)
                .HasForeignKey(t => t.TableId);
        }
    }
}
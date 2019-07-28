namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class StakeEntityTypeConfiguration : IEntityTypeConfiguration<Stake>
    {
        public void Configure(EntityTypeBuilder<Stake> builder)
        {
            builder.ToTable("Stakes");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(s => s.Currency)
                .HasColumnName("Currency")
                .HasColumnType("VARCHAR(3)")
                .HasMaxLength(3)
                .IsRequired(true);

            builder.Property(s => s.CurrencySymbol)
                .HasColumnName("CurrencySymbol")
                .HasColumnType("NVARCHAR(2)")
                .HasMaxLength(2)
                .IsRequired(true);

            builder.Property(s => s.SmallBlind)
                .HasColumnName("SmallBlind")
                .HasColumnType("MONEY")
                .IsRequired(true);

            builder.Property(s => s.BigBlind)
                .HasColumnName("BigBlind")
                .HasColumnType("MONEY")
                .IsRequired(true);

            builder
                .HasMany(s => s.Tables)
                .WithOne(s => s.Stake)
                .HasForeignKey(s => s.StakeId);
        }
    }
}
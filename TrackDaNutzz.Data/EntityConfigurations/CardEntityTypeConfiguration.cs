namespace TrackDaNutzz.Data.EntityConfigurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class CardEntityTypeConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("TINYINT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(a => a.Suit)
                .HasColumnName("Suit")
                .HasColumnType("VARCHAR(7)")
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(a => a.Rank)
                .HasColumnName("Rank")
                .HasMaxLength(1)
                .HasColumnType("CHAR(1)")
                .IsUnicode(false)
                .IsRequired(true);
        }
    }
}
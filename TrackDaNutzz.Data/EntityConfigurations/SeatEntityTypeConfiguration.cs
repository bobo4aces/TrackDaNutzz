namespace TrackDaNutzz.Data.EntityConfigurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class SeatEntityTypeConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seats");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("Id")
                .HasColumnType("BIGINT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(s => s.Number)
                .HasColumnName("Number")
                .HasColumnType("TINYINT")
                .IsRequired(true);

            builder.Property(s => s.PlayerId)
                .HasColumnName("PlayerId")
                .HasColumnType("INT")
                .IsRequired(true);

            builder.Property(s => s.StartStack)
                .HasColumnName("StartStack")
                .HasColumnType("MONEY")
                .IsRequired(true);

            builder.Property(s => s.FinalStack)
                .HasColumnName("FinalStack")
                .HasColumnType("MONEY")
                .IsRequired(true);

            builder.Property(s => s.HoleCards)
                .HasColumnName("HoleCards")
                .HasColumnType("VARCHAR(7)")
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsRequired(false);

            builder.Property(s => s.IsShowCards)
                .HasColumnName("IsShowCards")
                .HasColumnType("BIT")
                .IsRequired(true);

            builder.Property(s => s.HandId)
                .HasColumnName("HandId")
                .HasColumnType("BIGINT")
                .IsRequired(true);

            builder
                .HasOne(s => s.Hand)
                .WithMany(s => s.Seats)
                .HasForeignKey(s => s.Hand);
        }
    }
}
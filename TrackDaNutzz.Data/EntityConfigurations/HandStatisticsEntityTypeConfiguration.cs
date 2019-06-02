namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class HandStatisticsEntityTypeConfiguration : IEntityTypeConfiguration<HandStatistics>
    {
        public void Configure(EntityTypeBuilder<HandStatistics> builder)
        {
            builder.ToTable("HandStatistics");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .HasColumnType("BIGINT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(b => b.VoluntaryPutInPot)
                .HasColumnName("VoluntaryPutInPot")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(b => b.PreFlopRaise)
                .HasColumnName("PreFlopRaise")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(b => b.ThreeBet)
                .HasColumnName("ThreeBet")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(b => b.FourBet)
                .HasColumnName("FourBet")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(b => b.AggresionFactor)
                .HasColumnName("AggresionFactor")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(b => b.ContinuationBet)
                .HasColumnName("ContinuationBet")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(b => b.BigBlindsWon)
                .HasColumnName("BigBlindsWon")
                .HasColumnType("DECIMAL(15,2)")
                .IsRequired(true);
            builder.Property(b => b.DollarsWon)
                .HasColumnName("DollarsWon")
                .HasColumnType("MONEY")
                .IsRequired(true);
        }
    }
}

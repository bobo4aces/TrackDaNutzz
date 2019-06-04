namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class StatisticsEntityTypeConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            builder.ToTable("Statistics");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("Id")
                .HasColumnType("BIGINT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(s => s.VoluntaryPutInPot)
                .HasColumnName("VoluntaryPutInPot")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(s => s.PreFlopRaise)
                .HasColumnName("PreFlopRaise")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(s => s.ThreeBet)
                .HasColumnName("ThreeBet")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(s => s.FourBet)
                .HasColumnName("FourBet")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(s => s.AggresionFactor)
                .HasColumnName("AggresionFactor")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(s => s.ContinuationBet)
                .HasColumnName("ContinuationBet")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired(true);
            builder.Property(s => s.BigBlindsWon)
                .HasColumnName("BigBlindsWon")
                .HasColumnType("DECIMAL(15,2)")
                .IsRequired(true);
            builder.Property(s => s.DollarsWon)
                .HasColumnName("DollarsWon")
                .HasColumnType("MONEY")
                .IsRequired(true);
            builder.Property(s => s.HandPlayer)
                .HasColumnName("HandPlayer")
                .HasColumnType("MONEY")
                .IsRequired(true);

            //TODO: add relations
        }
    }
}

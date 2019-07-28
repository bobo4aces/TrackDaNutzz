namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class StatisticEntityTypeConfiguration : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> builder)
        {
            builder.ToTable("Statistics");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("Id")
                .HasColumnType("BIGINT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(s => s.VoluntaryPutMoneyInPot)
                .HasColumnName("VoluntaryPutMoneyInPot")
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

            builder.Property(s => s.AggressionFactor)
                .HasColumnName("AggressionFactor")
                .HasColumnType("DECIMAL(15,2)")
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

            builder.Property(s => s.MoneyWon)
                .HasColumnName("MoneyWon")
                .HasColumnType("MONEY")
                .IsRequired(true);

            builder
                .HasMany(s => s.HandPlayers)
                .WithOne(s => s.Statistic)
                .HasForeignKey(s => s.StatisticId);
        }
    }
}

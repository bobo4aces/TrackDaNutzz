namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class HandPlayerEntityTypeConfiguration : IEntityTypeConfiguration<HandPlayer>
    {
        public void Configure(EntityTypeBuilder<HandPlayer> builder)
        {
            builder.ToTable("HandPlayers");
            builder.HasKey(hp => new { hp.HandId, hp.PlayerId });

            builder.Property(hp=>hp.HandId)
                .HasColumnName("HandId")
                .HasColumnType("BIGINT")
                .IsRequired(true);
            builder.Property(hp => hp.PlayerId)
               .HasColumnName("PlayerId")
               .HasColumnType("INT")
               .IsRequired(true);

            builder.Property(hp => hp.StatisticsId)
               .HasColumnName("StatisticsId")
               .HasColumnType("BIGINT")
               .IsRequired(true);

            builder.Property(s => s.SeatNumber)
                .HasColumnName("SeatNumber")
                .HasColumnType("TINYINT")
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

            builder.Property(a => a.IsAllIn)
                .HasColumnName("IsAllIn")
                .HasColumnType("BIT")
                .IsRequired(true);

            builder
                .HasOne(hp => hp.Hand)
                .WithMany(hp => hp.HandPlayers)
                .HasForeignKey(hp => hp.HandId);

            builder
               .HasOne(hp => hp.Player)
               .WithMany(hp => hp.HandPlayers)
               .HasForeignKey(hp => hp.PlayerId);
            

            //TODO: add relations
        }
    }
}

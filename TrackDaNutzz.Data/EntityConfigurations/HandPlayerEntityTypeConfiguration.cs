namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    //internal class HandPlayerEntityTypeConfiguration : IEntityTypeConfiguration<HandPlayer>
    //{
    //    public void Configure(EntityTypeBuilder<HandPlayer> builder)
    //    {
    //        builder.ToTable("HandPlayers");
    //        builder.HasKey(hp => new { hp.HandId, hp.PlayerId });
    //
    //        builder.Property(hp=>hp.HandId)
    //            .HasColumnName("HandId")
    //            .HasColumnType("BIGINT")
    //            .IsRequired(true);
    //
    //        builder.Property(hp => hp.PlayerId)
    //           .HasColumnName("PlayerId")
    //           .HasColumnType("INT")
    //           .IsRequired(true);
    //
    //
    //        builder.Property(hp => hp.StartingStack)
    //            .HasColumnName("StartingStack")
    //            .HasColumnType("MONEY")
    //            .IsRequired(true);
    //
    //        builder.Property(hp => hp.FinalStack)
    //            .HasColumnName("FinalStack")
    //            .HasColumnType("MONEY")
    //            .IsRequired(true);
    //
    //        builder.Property(hp => hp.SeatNumber)
    //            .HasColumnName("SeatNumber")
    //            .HasColumnType("TINYINT")
    //            .IsRequired(true);
    //
    //        builder.Property(hp => hp.HoleCards)
    //            .HasColumnName("HoleCards")
    //            .HasColumnType("VARCHAR(7)")
    //            .HasMaxLength(7)
    //            .IsUnicode(false)
    //            .IsRequired(false);
    //
    //        builder.Property(hp => hp.IsInPosition)
    //            .HasColumnName("IsInPosition")
    //            .HasColumnType("BIT")
    //            .HasDefaultValue(0)
    //            .IsRequired(true);
    //
    //        builder.Property(hp => hp.IsMuckCards)
    //            .HasColumnName("IsMuckCards")
    //            .HasColumnType("BIT")
    //            .HasDefaultValue(0)
    //            .IsRequired(true);
    //
    //        builder.Property(hp => hp.HasShowdown)
    //            .HasColumnName("HasShowdown")
    //            .HasColumnType("BIT")
    //            .HasDefaultValue(0)
    //            .IsRequired(true);
    //
    //        builder.Property(hp => hp.IsAllIn)
    //            .HasColumnName("IsAllIn")
    //            .HasColumnType("BIT")
    //            .HasDefaultValue(0)
    //            .IsRequired(true);
    //
    //        builder.Property(hp => hp.PositionId)
    //            .HasColumnName("PositionId")
    //            .HasColumnType("INT")
    //            .IsRequired(true);
    //
    //        builder.Property(hp => hp.StatisticId)
    //           .HasColumnName("StatisticId")
    //           .HasColumnType("BIGINT")
    //           .IsRequired(true);
    //
    //        builder
    //            .HasOne(hp => hp.Hand)
    //            .WithMany(hp => hp.HandPlayers)
    //            .HasForeignKey(hp => hp.HandId);
    //
    //        builder
    //           .HasOne(hp => hp.Player)
    //           .WithMany(hp => hp.HandPlayers)
    //           .HasForeignKey(hp => hp.PlayerId);
    //        
    //        //TODO: add relations
    //    }
    //}
}

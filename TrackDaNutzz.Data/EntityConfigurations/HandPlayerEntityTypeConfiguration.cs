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

            builder
                .HasOne(hp => hp.Hand)
                .WithMany(hp => hp.HandPlayers)
                .HasForeignKey(hp => hp.HandId);

            builder
               .HasOne(hp => hp.Player)
               .WithMany(hp => hp.HandPlayers)
               .HasForeignKey(hp => hp.PlayerId);
        }
    }
}

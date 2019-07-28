namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

   // internal class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
   // {
   //     public void Configure(EntityTypeBuilder<Player> builder)
   //     {
   //         builder.ToTable("Players");
   //         builder.HasKey(p => p.Id);
   //
   //         builder.Property(p => p.Id)
   //             .HasColumnName("Id")
   //             .HasColumnType("INT")
   //             .ValueGeneratedOnAdd()
   //             .IsRequired(true);
   //
   //         builder.Property(p => p.Name)
   //             .HasColumnName("Name")
   //             .HasColumnType("VARCHAR(30)")
   //             .HasMaxLength(30)
   //             .IsUnicode(false)
   //             .IsRequired(true);
   //
   //         builder.Property(p => p.IsActive)
   //             .HasColumnName("IsActive")
   //             .HasColumnType("BIT")
   //             .HasDefaultValue(0)
   //             .IsRequired(true);
   //
   //         builder
   //             .HasMany(p => p.HandPlayers)
   //             .WithOne(p => p.Player)
   //             .HasForeignKey(p => p.PlayerId);
   //     }
   // }
}
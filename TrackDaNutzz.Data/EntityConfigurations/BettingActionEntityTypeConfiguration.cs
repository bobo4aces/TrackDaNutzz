namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    ////internal class BettingActionEntityTypeConfiguration : IEntityTypeConfiguration<BettingAction>
    ////{
    ////
    ////    public void Configure(EntityTypeBuilder<BettingAction> builder)
      //  {
      //      builder.ToTable("BettingActions");
      //      builder.HasKey(b => b.Id);
      //
      //      builder.Property(b => b.Id)
      //          .HasColumnName("Id")
      //          .HasColumnType("BIGINT")
      //          .ValueGeneratedOnAdd()
      //          .IsRequired(true);
      //
      //      builder.Property(a => a.Round)
      //          .HasColumnName("Round")
      //          .HasColumnType("VARCHAR(10)")
      //          .HasMaxLength(10)
      //          .IsUnicode(false)
      //          .IsRequired(true);
      //
      //      builder.Property(b => b.Type)
      //          .HasColumnName("Type")
      //          .HasColumnType("BIT")
      //          .HasDefaultValue(false)
      //          .IsRequired(true);
      //
      //      builder.Property(b => b.Name)
      //          .HasColumnName("Name")
      //          .HasColumnType("VARCHAR(20)")
      //          .HasMaxLength(20)
      //          .IsUnicode(false)
      //          .IsRequired(true);
      //
      //      builder.Property(b => b.Value)
      //          .HasColumnName("Value")
      //          .HasColumnType("MONEY")
      //          .IsRequired(false);
      //
      //      //TODO: Add relations
      //  }
    ////}
}
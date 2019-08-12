namespace TrackDaNutzz.Data.EntityConfigurations
{

    //internal class PositionEntityTypeConfiguration : IEntityTypeConfiguration<Position>
    //{
    //    public void Configure(EntityTypeBuilder<Position> builder)
    //    {
    //        builder.ToTable("Positions");
    //        builder.HasKey(p => p.Id);
    //
    //        builder.Property(p => p.Id)
    //            .HasColumnName("Id")
    //            .HasColumnType("INT")
    //            .ValueGeneratedOnAdd()
    //            .IsRequired(true);
    //
    //        builder.Property(p => p.Name)
    //            .HasColumnName("Name")
    //            .HasColumnType("VARCHAR(10)")
    //            .HasMaxLength(10)
    //            .IsUnicode(false)
    //            .IsRequired(true);
    //
    //        builder.Property(p => p.Type)
    //            .HasColumnName("Type")
    //            .HasColumnType("VARCHAR(20)")
    //            .HasMaxLength(20)
    //            .IsUnicode(false)
    //            .IsRequired(true);
    //
    //        builder
    //            .HasMany(p => p.HandPlayers)
    //            .WithOne(p => p.Position)
    //            .HasForeignKey(p => p.PositionId);
    //    }
    //}
}
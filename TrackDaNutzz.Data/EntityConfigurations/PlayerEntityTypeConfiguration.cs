namespace TrackDaNutzz.Data.EntityConfigurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(p => p.Stack)
                .HasColumnName("Stack")
                .HasColumnType("MONEY")
                .IsRequired(true);
        }
    }
}
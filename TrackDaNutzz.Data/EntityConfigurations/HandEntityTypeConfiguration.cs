namespace TrackDaNutzz.Data.EntityConfigurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class HandEntityTypeConfiguration : IEntityTypeConfiguration<Hand>
    {
        public void Configure(EntityTypeBuilder<Hand> builder)
        {
            builder.ToTable("Hands");
            builder.HasKey(h => h.Id);
    
            builder.Property(h => h.Id)
                .HasColumnName("Id")
                .HasColumnType("BIGINT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);
    
            builder.Property(h => h.Number)
                .HasColumnName("Number")
                .HasColumnType("BIGINT")
                .IsRequired(true);
    
            builder.Property(h => h.Time)
                .HasColumnName("Time")
                .HasColumnType("DATETIME2")
                .IsRequired(true);

            builder.Property(h => h.TimeZone)
                .HasColumnName("TimeZone")
                .HasColumnType("VARCHAR(3)")
                .HasMaxLength(3)
                .IsRequired(true);

            builder.Property(h => h.LocalTime)
                .HasColumnName("LocalTime")
                .HasColumnType("DATETIME2")
                .IsRequired(true);

            builder.Property(h => h.LocalTimeZone)
                .HasColumnName("LocalTimeZone")
                .HasColumnType("VARCHAR(3)")
                .HasMaxLength(3)
                .IsRequired(true);

            builder.Property(h => h.Button)
                .HasColumnName("Button")
                .HasColumnType("TINYINT")
                .IsRequired(true);
    
            builder.Property(h => h.Pot)
                .HasColumnName("Pot")
                .HasColumnType("MONEY")
                .IsRequired(true);
    
            builder.Property(h => h.Rake)
                .HasColumnName("Rake")
                .HasColumnType("MONEY")
                .IsRequired(true);
    
            builder.Property(h => h.TableId)
                .HasColumnName("TableId")
                .HasColumnType("INT")
                .IsRequired(true);
    
            builder.Property(h => h.BoardId)
                .HasColumnName("BoardId")
                .HasColumnType("BIGINT")
                .IsRequired(false);
    
            builder
                .HasOne(h => h.Table)
                .WithMany(h => h.Hands)
                .HasForeignKey(h => h.TableId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.Board)
                .WithMany(h => h.Hands)
                .HasForeignKey(h => h.BoardId);

            builder
                .HasMany(h => h.HandPlayers)
                .WithOne(h => h.Hand)
                .HasForeignKey(h => h.HandId);
        }
    }
}
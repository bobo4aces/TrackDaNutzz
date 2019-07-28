namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class BoardEntityTypeConfiguration : IEntityTypeConfiguration<Board>
    {

        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable("Boards");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .HasColumnType("BIGINT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(b => b.Flop)
                .HasColumnName("Flop")
                .HasColumnType("VARCHAR(11)")
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(b => b.Turn)
                .HasColumnName("Turn")
                .HasColumnType("VARCHAR(3)")
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsRequired(false);

            builder.Property(b => b.River)
                .HasColumnName("River")
                .HasColumnType("VARCHAR(3)")
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsRequired(false);

            builder
                .HasMany(b => b.Hands)
                .WithOne(b => b.Board)
                .HasForeignKey(b => b.BoardId);
        }
    }
}
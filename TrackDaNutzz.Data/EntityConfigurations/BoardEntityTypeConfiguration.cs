namespace TrackDaNutzz.Data.EntityConfigurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class BoardEntityTypeConfiguration : IEntityTypeConfiguration<Board>
    {

        public int Id { get; protected set; }

        public string Flop { get; protected set; }

        public string Turn { get; protected set; }

        public string River { get; protected set; }

        public long HandId { get; protected set; }

        public Hand Hand { get; protected set; }

        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable("Boards");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(b => b.Flop)
                .HasColumnName("Flop")
                .HasColumnType("VARCHAR(11)")
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsRequired(false);

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

            builder.Property(b => b.HandId)
                .HasColumnName("HandId")
                .HasColumnType("BIGINT")
                .IsRequired(true);
        }
    }
}
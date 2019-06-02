namespace TrackDaNutzz.Data.EntityConfigurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class ActionEntityTypeConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("Actions");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("BIGINT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(a => a.Street)
                .HasColumnName("Street")
                .HasColumnType("VARCHAR(7)")
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(a => a.PlayerId)
                .HasColumnName("PlayerId")
                .HasColumnType("INT")
                .IsRequired(true);

            builder.Property(a => a.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(17)")
                .HasMaxLength(17)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(a => a.Value)
                .HasColumnName("Value")
                .HasColumnType("MONEY")
                .IsRequired(false);

            builder.Property(a => a.IsAllIn)
                .HasColumnName("IsAllIn")
                .HasColumnType("BIT")
                .IsRequired(true);

            builder.Property(a => a.HandId)
                .HasColumnName("HandId")
                .HasColumnType("BIGINT")
                .IsRequired(true);
        }
    }
}
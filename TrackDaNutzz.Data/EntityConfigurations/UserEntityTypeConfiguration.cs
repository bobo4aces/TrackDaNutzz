namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("VARCHAR(30)")
                .HasMaxLength(30)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasColumnType("VARCHAR(30)")
                .HasMaxLength(30)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(p => p.Birthday)
                .HasColumnName("Birthday")
                .HasColumnType("DATETIME2")
                .IsRequired(true);

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(30)")
                .HasMaxLength(30)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(p => p.Password)
                .HasColumnName("Password")
                .HasColumnType("VARCHAR(30)")
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired(true);

            //TODO: Add relations
        }
    }
}
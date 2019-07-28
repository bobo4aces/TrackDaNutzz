namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    internal class TrackDaNutzzUserEntityTypeConfiguration : IEntityTypeConfiguration<TrackDaNutzzUser>
    {
        public void Configure(EntityTypeBuilder<TrackDaNutzzUser> builder)
        {
            builder.ToTable("AspNetUsers");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("NVARCHAR(450)")
                .HasMaxLength(450)
                .IsUnicode(true)
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("NVARCHAR(100)")
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR(100)")
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(p => p.Birthday)
                .HasColumnName("Birthday")
                .HasColumnType("DATETIME2")
                .IsRequired(true);

            builder.Property(p => p.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("VARCHAR(100)")
                .IsRequired(true);

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR(256)")
                .HasMaxLength(256)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(p => p.Password)
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR(450)")
                .HasMaxLength(450)
                .IsUnicode(true)
                .IsRequired(true);

            builder
                .HasMany(t => t.Players)
                .WithOne(t => t.TrackDaNutzzUser)
                .HasForeignKey(t => t.TrackDaNutzzUserId);
        }
    }
}
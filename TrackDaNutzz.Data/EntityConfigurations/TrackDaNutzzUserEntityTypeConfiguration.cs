namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

    //internal class TrackDaNutzzUserEntityTypeConfiguration : IEntityTypeConfiguration<TrackDaNutzzUser>
    //{
    //    public void Configure(EntityTypeBuilder<TrackDaNutzzUser> builder)
    //    {
    //        builder.ToTable("Users");
    //        builder.HasKey(p => p.Id);
    //
    //        builder.Property(p => p.Id)
    //            .HasColumnName("Id")
    //            .HasColumnType("VARCHAR(36)")
    //            .HasMaxLength(36)
    //            .ValueGeneratedOnAdd()
    //            .IsRequired(true);
    //
    //        builder.Property(p => p.FirstName)
    //            .HasColumnName("FirstName")
    //            .HasColumnType("VARCHAR(30)")
    //            .HasMaxLength(30)
    //            .IsUnicode(true)
    //            .IsRequired(true);
    //
    //        builder.Property(p => p.LastName)
    //            .HasColumnName("LastName")
    //            .HasColumnType("VARCHAR(30)")
    //            .HasMaxLength(30)
    //            .IsUnicode(true)
    //            .IsRequired(true);
    //
    //        builder.Property(p => p.Birthday)
    //            .HasColumnName("Birthday")
    //            .HasColumnType("DATETIME2")
    //            .IsRequired(true);
    //
    //        builder.Property(p => p.Email)
    //            .HasColumnName("Email")
    //            .HasColumnType("VARCHAR(30)")
    //            .HasMaxLength(30)
    //            .IsUnicode(true)
    //            .IsRequired(true);
    //
    //        builder.Property(p => p.Password)
    //            .HasColumnName("Password")
    //            .HasColumnType("VARCHAR(30)")
    //            .HasMaxLength(30)
    //            .IsUnicode(false)
    //            .IsRequired(true);
    //
    //        //TODO: Add relations
    //    }
    //}
}
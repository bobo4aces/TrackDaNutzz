namespace TrackDaNutzz.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrackDaNutzz.Data.Models;

   //internal class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
   //{
   //
   //    public void Configure(EntityTypeBuilder<Client> builder)
   //    {
   //        builder.ToTable("Clients");
   //        builder.HasKey(c => c.Id);
   //
   //        builder.Property(c => c.Id)
   //            .HasColumnName("Id")
   //            .HasColumnType("INT")
   //            .ValueGeneratedOnAdd()
   //            .IsRequired(true);
   //
   //        builder.Property(c => c.Name)
   //            .HasColumnName("Name")
   //            .HasColumnType("VARCHAR(20)")
   //            .HasMaxLength(20)
   //            .IsUnicode(false)
   //            .IsRequired(true);
   //
   //        builder
   //            .HasMany(c => c.Tables)
   //            .WithOne(c => c.Client)
   //            .HasForeignKey(c => c.ClientId);
   //    }
   //}
}
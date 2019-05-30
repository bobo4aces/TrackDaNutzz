using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace TrackDaNutzz.Data
{
    public class TrackDaNutzzDbContext : DbContext
    {
        public TrackDaNutzzDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConfigurationString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

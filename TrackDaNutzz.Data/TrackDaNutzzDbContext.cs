namespace TrackDaNutzz.Data
{
    using Microsoft.EntityFrameworkCore;
    using TrackDaNutzz.Data.EntityConfigurations;
    using TrackDaNutzz.Data.Models;

    public class TrackDaNutzzDbContext : DbContext
    {
        //TODO: Add more DbSets. Check Protected Set
        public DbSet<TrackDaNutzz.Data.Models.Action> Action { get; protected set; }
        public DbSet<Board> Boards { get; protected set; }
        public DbSet<Card> Cards { get; protected set; }
        public DbSet<Hand> Hands { get; protected set; }
        public DbSet<HandPlayer> HandPlayers { get; protected set; }
        public DbSet<HandStatistics> HandStatistics { get; protected set; }
        public DbSet<Player> Players { get; protected set; }
        public DbSet<Seat> Seats { get; protected set; }
        public DbSet<Table> Tables { get; protected set; }
        public TrackDaNutzzDbContext(DbContextOptions<TrackDaNutzzDbContext> options) 
            : base(options)
        {
        }

        public TrackDaNutzzDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        //TODO: Add more configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BoardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HandPlayerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HandStatisticsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SeatEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TableEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

namespace TrackDaNutzz.Data
{
    using Microsoft.EntityFrameworkCore;
    using TrackDaNutzz.Data.EntityConfigurations;
    using TrackDaNutzz.Data.Models;

    public class TrackDaNutzzDbContext : DbContext
    {
        //TODO: Add more DbSets. Check Protected Set
        public DbSet<BettingAction> BettingActions { get; protected set; }
        public DbSet<Board> Boards { get; protected set; }
        public DbSet<Client> Clients { get; protected set; }
        public DbSet<Hand> Hands { get; protected set; }
        public DbSet<HandPlayer> HandPlayers { get; protected set; }
        public DbSet<Player> Players { get; protected set; }
        public DbSet<Position> Positions { get; protected set; }
        public DbSet<Stake> Stakes { get; protected set; }
        public DbSet<Statistic> Statistics { get; protected set; }
        public DbSet<Table> Tables { get; protected set; }
        public DbSet<User> Users { get; protected set; }
        public DbSet<Variant> Variants { get; protected set; }

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
            modelBuilder.ApplyConfiguration(new BettingActionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BoardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HandPlayerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StakeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatisticEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TableEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VariantEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

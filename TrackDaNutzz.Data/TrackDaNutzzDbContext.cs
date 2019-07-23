namespace TrackDaNutzz.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TrackDaNutzz.Data.EntityConfigurations;
    using TrackDaNutzz.Data.Models;

    public class TrackDaNutzzDbContext : IdentityDbContext<TrackDaNutzzUser, TrackDaNutzzRole, string>
    {
        public DbSet<TrackDaNutzzUser> TrackDaNutzzUsers { get; set; }
        public DbSet<TrackDaNutzzRole> TrackDaNutzzRoles { get; set; }
        public DbSet<BettingAction> BettingActions { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Hand> Hands { get; set; }
        public DbSet<HandPlayer> HandPlayers { get; set; }
        public DbSet<Player> Players { get; set; }
        //public DbSet<Position> Positions { get; set; }
        public DbSet<Stake> Stakes { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Variant> Variants { get; set; }

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
            modelBuilder.Entity<HandPlayer>()
                .HasKey(x => new { x.HandId, x.PlayerId });
            //modelBuilder.ApplyConfiguration(new BettingActionEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new BoardEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new HandEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new HandPlayerEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new PositionEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new StakeEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new StatisticEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new TableEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new TrackDaNutzzUserEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new VariantEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

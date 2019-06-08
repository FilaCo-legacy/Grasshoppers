using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public sealed class PlatformerContext : DbContext
    {
        public DbSet<InventoryEntry> Inventories { get; set; }
        
        public DbSet <Item> Items { get; set; }
        
        public DbSet <Character> Characters { get; set; }
        
        public DbSet<GameSession> GameSessions { get; set; }
        
        public DbSet<Mission> Missions { get; set; }
        
        public DbSet<Map> Maps { get; set; }
        
        public DbSet<CharacterResultEntry> CharactersResults { get; set; }
        
        public PlatformerContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new MissionConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterResultEntryConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
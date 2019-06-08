using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public sealed class PlatformerContext : DbContext
    {
        public DbSet<InventoryEntry> ItemsPlayers { get; set; }
        
        public DbSet <Item> Items { get; set; }
        
        public DbSet <Character> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new MissionConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterResultEntryConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
        
        public PlatformerContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
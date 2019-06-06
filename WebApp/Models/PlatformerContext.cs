using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public sealed class PlatformerContext : DbContext
    {
        public DbSet<ItemsPlayers> ItemsPlayers { get; set; }
        
        public DbSet <Item> Items { get; set; }
        
        public DbSet <Player> Players { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            //modelBuilder.ApplyConfiguration(new ItemConfiguration());
//        }
        
        public PlatformerContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
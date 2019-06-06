using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public sealed class InventoryContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        
        public DbSet<Item> Items { get; set; }
        
        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
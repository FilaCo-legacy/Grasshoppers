using System.Data.Entity;
using GameServer.DBModels;
using GameServer.DBModels.Configurations;

namespace GameServer
{
    public class PlatformerContext:DbContext
    {
        public DbSet<Player> Players { get; set; }
        
        public DbSet<Item> Items { get; set; }

        public DbSet<Map> Maps { get; set; }
        
        public DbSet<Mission> Missions { get; set; }

        public DbSet<Trade> Trades { get; set; }
        
        public DbSet<GameSession> GameSessions { get; set; }

        public DbSet<PlayerResultEntry> PlayerResultEntries { get; set; }
        
        public PlatformerContext(string nameOrConnectionString) : base(nameOrConnectionString: nameOrConnectionString)
        {
            
        }
        
        public PlatformerContext() : base(nameOrConnectionString: "PlatformerDB")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapDefaultConfig());
            modelBuilder.Configurations.Add(new TradeDefaultConfig());
        }
    }
}
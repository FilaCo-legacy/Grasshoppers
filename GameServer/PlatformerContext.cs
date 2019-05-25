using System.Data.Entity;
using GameServer.DBModels;

namespace GameServer
{
    public class PlatformerContext:DbContext
    {
        public PlatformerContext(string nameOrConnectionString) : base(nameOrConnectionString: nameOrConnectionString)
        {
            
        }
        
        public PlatformerContext() : base(nameOrConnectionString: "PlatformerDB")
        {
            
        }

        public DbSet<Player> Players { get; set; }
        
        public DbSet<Item> Items { get; set; }

        //public DbSet<Map> Maps { get; set; }
        
        //public DbSet<Mission> Missions { get; set; }

        //public DbSet<Trade> Trades { get; set; }
    }
}
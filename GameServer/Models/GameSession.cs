using System.Collections.Generic;

namespace GameServer.Models
{
    public class GameSession
    {
        public int Id { get; set; }
        
        public ICollection<Player> Players { get; set; }
        
        public ICollection<LogGameSession> Logs { get; set; }
    }
}
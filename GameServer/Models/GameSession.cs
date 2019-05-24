using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    public class GameSession
    {
        public int Id { get; set; }
        
        public DateTime BeginDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        
        
        public ICollection<Player> Players { get; set; }
    }
}
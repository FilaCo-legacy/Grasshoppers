using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    public class GameSession
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime BeginDateTime { get; set; }
        
        [Required]
        public DateTime EndDateTime { get; set; }
        
        public int MissionId { get; set; }
        
        [ForeignKey("MissionId")]
        public Mission GsMission { get; set; }

        public ICollection<Player> Players { get; set; }

        public GameSession()
        {
            Players = new List<Player>();
        }
    }
}
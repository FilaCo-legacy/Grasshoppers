using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.Models
{
    public class Player
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        
        public ICollection<Item> Items { get; set; }
        
        public ICollection<GameSession> GameSessions { get; set; }
        
        
        public int AppearanceId { get; set; }
        
        [ForeignKey("AppearanceId")]
        public PlayerAppearance Appearance { get; set; }

        public Player()
        {
            Items = new List<Item>();
            GameSessions = new List<GameSession>();
        }
    }
}
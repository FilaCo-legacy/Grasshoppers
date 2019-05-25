using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    public class Player
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<Item> Items { get; set; }
        
        public ICollection<GameSession> GameSessions { get; set; }
        
        public PlayerAppearance PlayerAppearance { get; set; }

        public Player()
        {
            PlayerAppearance = new PlayerAppearance();
            Items = new List<Item>();
            GameSessions = new List<GameSession>();
        }
    }
}
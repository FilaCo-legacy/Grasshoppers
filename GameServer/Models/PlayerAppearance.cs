using System.Collections.Generic;

namespace GameServer.Models
{
    public enum GenderValue
    {
        Man,
        Woman
    };

    public class PlayerAppearance
    {
        public int Id { get; set; }
        
        public GenderValue Gender { get; set; }
        
        public int HairColor { get; set; }
        
        public int ShirtColor { get; set; }
        
        public int BootsColor { get; set; }
        
        public string SpritePath { get; set; }
        
        public ICollection<Player> Players { get; set; }

        public PlayerAppearance()
        {
            Players = new List<Player>();
        }
    }
}
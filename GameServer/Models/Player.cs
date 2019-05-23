using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.Models
{
    public class Player
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int AppearanceId { get; set; }
        
        [ForeignKey("PlayerAppearance")]
        public PlayerAppearance Appearance { get; set; }
    }
}
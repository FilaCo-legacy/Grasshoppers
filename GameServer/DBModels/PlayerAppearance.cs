using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    [ComplexType]
    public class PlayerAppearance
    {
        [Required]
        public int HairColor { get; set; }
        
        [Required]
        public int ShirtColor { get; set; }
        
        [Required]
        public int BootsColor { get; set; }
        
        [Required]
        public string SpritePath { get; set; }
    }
}
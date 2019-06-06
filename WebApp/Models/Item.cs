using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public ItemRarity Rarity { get; set; }
        
        [Required]
        public string SpritePath { get; set; }
        
//        public ICollection<Player> Players { get; set; }
//
//        public Item()
//        {
//            Players = new List<Player>();
//        }
    }
}
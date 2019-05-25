using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Mythical,
        Legendary
    }
    
    public class Item
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public ItemRarity Rarity { get; set; }
        
        public ICollection<Player> Players { get; set; }

        public Item()
        {
            Players = new List<Player>();
        }
    }
}
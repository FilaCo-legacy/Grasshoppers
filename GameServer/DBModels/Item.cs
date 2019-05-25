using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    /// <summary>
    /// Enum to discrete <see cref="Item"/>'s rarity
    /// </summary>
    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Mythical,
        Legendary
    }
    
    /// <summary>
    /// Class that represents an item in some <see cref="Player"/>'s inventory
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        
        /// <summary>
        /// A name of this <see cref="Item"/>
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// A rarity rate for this <see cref="Item"/>
        /// </summary>
        [Required]
        public ItemRarity Rarity { get; set; }
        
        /// <summary>
        /// A collection of <see cref="Player"/>s which have this <see cref="Item"/> in their inventory
        /// </summary>
        public ICollection<Player> Players { get; set; }

        public Item()
        {
            Players = new List<Player>();
        }
    }
}
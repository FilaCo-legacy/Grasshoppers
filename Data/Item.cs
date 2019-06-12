using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grasshoppers.Data
{
    /// <summary>
    /// Represents an item in the database
    /// </summary>
    public class Item
    {
        [Required]
        internal string Sprite { get; private set; }
        
        public int Id { get; set; }
        
        [Required, MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        
        /// <summary>
        /// Some important info about this item
        /// </summary>
        public string Description { get; set; }
        
        [Required]
        public ItemRarity Rarity { get; set; }
        
        /// <summary>
        /// Stores inventory entries which include this item
        /// </summary>
        public ICollection<InventoryEntry> InventoryEntries{ get; set; }

        public Item()
        {
            InventoryEntries = new List<InventoryEntry>();
        }
    }
}
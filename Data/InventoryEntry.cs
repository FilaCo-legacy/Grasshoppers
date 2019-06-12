using System.ComponentModel.DataAnnotations.Schema;

namespace Grasshoppers.Data
{
    public class InventoryEntry
    {
        public int Id { get; set; }
        
        public int CharacterId { get; set; }
        
        public int ItemId { get; set; }
        
        [ForeignKey("CharacterId")]
        public Character Owner { get; set; }
        
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class InventoryEntry
    {
        public int Id { get; set; }
        
        public int PlayerId { get; set; }
        
        public int ItemId { get; set; }
        
        [ForeignKey("PlayerId")]
        public Character Owner { get; set; }
        
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
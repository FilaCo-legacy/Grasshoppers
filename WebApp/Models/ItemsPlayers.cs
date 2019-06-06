using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class ItemsPlayers
    {
        public int Id { get; set; }
        
        public int PlayerId { get; set; }
        
        public int ItemId { get; set; }
        
        [ForeignKey("PlayerId")]
        public Player Owner { get; set; }
        
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    public class AwardEntry
    {
        [Key]
        [ForeignKey("PlayerResultEntry")]
        public int Id { get; set; }
        
        public int PlayerId { get; set; }
        
        public int ItemId { get; set; }

        [ForeignKey("PlayerId")]
        public Player AwardedPlayer { get; set; }
        
        [ForeignKey("ItemId")]
        public Item AwardItem { get; set; }
    }
}
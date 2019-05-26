using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    /// <summary>
    /// Class that contains information about an award for the <see cref="Player"/> from completed <see cref="GameSession"/>
    /// </summary>
    public class AwardEntry
    {
        [Key, ForeignKey("PlayerResultEntry")]
        public int Id { get; set; }
        
        public int PlayerId { get; set; }
        
        public int ItemId { get; set; }

        [ForeignKey("PlayerId")]
        public Player AwardedPlayer { get; set; }
        
        [ForeignKey("ItemId")]
        public Item AwardItem { get; set; }
    }
}
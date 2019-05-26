using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    /// <summary>
    /// Class that contains information about participator results in some <see cref="GameSession"/>
    /// </summary>
    public class PlayerResultEntry
    {
        [Key, Column(Order = 1)]
        public int PlayerId { get; set; }
        
        [Key, Column(Order = 2)]
        public int GameSessionId { get; set; }
        
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }
        
        [ForeignKey("GameSessionId")]
        public GameSession GameSession { get; set; }
        
        public int? ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item AwardItem { get; set; }
        
        public int StunnedPlayers { get; set; }
    }
}
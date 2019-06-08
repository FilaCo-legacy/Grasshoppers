using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    /// <summary>
    /// Represents information about participator results in some <see cref="GameSession"/>
    /// </summary>
    public class CharacterResultEntry
    {
        public int PlayerId { get; set; }
        
        public int GameSessionId { get; set; }

        [ForeignKey("PlayerId")] 
        public Character Character { get; set; }

        [ForeignKey("GameSessionId")] 
        public GameSession GameSession { get; set; }

        public int? StunnedPlayers { get; set; }
        
        public int? CapturedFlags { get; set; }
    }
}
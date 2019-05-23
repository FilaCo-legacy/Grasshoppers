using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.Models
{
    public class LogGameSession
    {
        public int Id { get; set; }
        
        public int GameSessionId { get; set; }
        
        [ForeignKey("GameSessionId")]
        public GameSession Session { get; set; }
        
        public string Message { get; set; }
    }
}
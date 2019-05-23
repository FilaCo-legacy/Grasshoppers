using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.Models
{
    public enum MissionType
    {
        Single,
        Team,
        BattleRoyale
    };
    
    public class Mission
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public MissionType Type { get; set; }
        
        public int MapId { get; set; }
        
        [ForeignKey("MapId")]
        public Map MissionMap { get; set; }
    }
}
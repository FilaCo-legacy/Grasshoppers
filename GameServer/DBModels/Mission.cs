using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    public class Mission
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public int MapId { get; set; }
        
        [ForeignKey("MapId")]
        public Map MissionMap { get; set; }
        
        [Required]
        public int RequiredPlayersNumber { get; set; }
        
        [Required]
        public int TargetScore { get; set; }
    }
}
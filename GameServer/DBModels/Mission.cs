using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    /// <summary>
    /// Class that implements the free-to-all fight mission
    /// </summary>
    public class Mission
    {
        public int Id { get; set; }
        
        /// <summary>
        /// A unique name of this <see cref="Mission"/>
        /// </summary>
        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        public int MapId { get; set; }
        
        /// <summary>
        /// A <see cref="Map"/> for this <see cref="Mission"/>
        /// </summary>
        [ForeignKey("MapId")]
        public Map MissionMap { get; set; }
        
        /// <summary>
        /// A number of <see cref="Player"/>s that this<see cref="Mission"/> requires
        /// </summary>
        [Required]
        public int RequiredPlayersNumber { get; set; }
        
        /// <summary>
        /// A number of stunned <see cref="Player"/>s that participators have to get
        /// </summary>
        [Required]
        public int TargetScore { get; set; }
    }
}
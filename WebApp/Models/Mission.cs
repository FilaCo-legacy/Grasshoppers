using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Mission
    {
        public int Id { get; set; }
        
        /// <summary>
        /// A unique name of this <see cref="Mission"/>
        /// </summary>
        [Required, MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        
        public int MapId { get; set; }
        
        /// <summary>
        /// A <see cref="Map"/> for this <see cref="Mission"/>
        /// </summary>
        [ForeignKey("MapId")]
        public Map MissionMap { get; set; }
        
        /// <summary>
        /// A number of <see cref="Character"/>s that this<see cref="Mission"/> requires
        /// </summary>
        [Required]
        public int RequiredPlayersNumber { get; set; }
        
        /// <summary>
        /// A number of stunned <see cref="Character"/>s that participators have to get
        /// </summary>
        [Required]
        public int TargetScore { get; set; }
    }
}
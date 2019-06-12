using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grasshoppers.Data
{
    /// <summary>
    /// Represents an info about mission in the database
    /// </summary>
    public class Mission
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        
        public int MapId { get; set; }
        
        /// <summary>
        /// Map that used in this mission
        /// </summary>
        [ForeignKey("MapId")]
        public Map MissionMap { get; set; }
        
        /// <summary>
        /// A number of <see cref="Character"/>s that this<see cref="Mission"/> requires
        /// </summary>
        [Required]
        public int RequiredParticipatorsNumber { get; set; }
        
        /// <summary>
        /// A number of stunned <see cref="Character"/>s that participators have to get
        /// </summary>
        public int? TargetScore { get; set; }
        
        /// <summary>
        /// A number of flags that team have to get to win this mission
        /// </summary>
        public int? TargetCapturedFlags { get; set; }
    }
}
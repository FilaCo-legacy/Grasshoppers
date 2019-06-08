using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    /// <summary>
    /// Represents info about some game session in the database
    /// </summary>
    public class GameSession
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Contains info of the date when this <see cref="GameSession"/> began
        /// </summary>
        [Required]
        public DateTime BeginDateTime { get; set; }
        
        /// <summary>
        /// Contains info of the date when this <see cref="GameSession"/> ended
        /// </summary>
        [Required]
        public DateTime EndDateTime { get; set; }
        
        public int MissionId { get; set; }
        
        /// <summary>
        /// Type of mission played
        /// </summary>
        [ForeignKey("MissionId")]
        public Mission Mission { get; set; }

        /// <summary>
        /// Results of each participated <see cref="Character"/>
        /// </summary>
        public ICollection<CharacterResultEntry> ParticipatorsResults { get; set; }

        public GameSession()
        {
            ParticipatorsResults = new List<CharacterResultEntry>();
        }
    }
}
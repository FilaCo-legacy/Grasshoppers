using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.DBModels
{
    /// <summary>
    /// Class that represents the game session
    /// </summary>
    public class GameSession
    {
        public int Id { get; set; }
        
        /// <summary>
        /// <see cref="DateTime"/> object that contains info of the date when this <see cref="GameSession"/> began
        /// </summary>
        [Required]
        public DateTime BeginDateTime { get; set; }
        
        /// <summary>
        /// <see cref="DateTime"/> object that contains info of the date when this <see cref="GameSession"/> ended
        /// </summary>
        [Required]
        public DateTime EndDateTime { get; set; }
        
        public int MissionId { get; set; }
        
        /// <summary>
        /// <see cref="Mission"/> object which was played by participators
        /// </summary>
        [ForeignKey("MissionId")]
        public Mission GsMission { get; set; }

        /// <summary>
        /// Participators of this <see cref="GameSession"/>
        /// </summary>
        public ICollection<Player> Players { get; set; }
        
        /// <summary>
        /// Results of each participated <see cref="Player"/>
        /// </summary>
        public ICollection<PlayerResultEntry> PlayerResults { get; set; }

        public GameSession()
        {
            Players = new List<Player>();
            PlayerResults = new List<PlayerResultEntry>();
        }
    }
}
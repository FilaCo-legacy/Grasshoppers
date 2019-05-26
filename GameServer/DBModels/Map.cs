using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameServer.GameCycle;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameServer.DBModels
{
    /// <summary>
    /// Class that contains the map information with serialization
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Serialized <see cref="MapInfo"/> object
        /// </summary>
        internal string _mapInfo { get; private set; }
        
        public int Id { get; set; }
        
        /// <summary>
        /// A collection of <see cref="Mission"/>s that use this <see cref="Map"/>
        /// </summary>
        public ICollection<Mission> Missions { get; set; }

        /// <summary>
        /// Deserialized <see cref="MapInfo"/> object
        /// </summary>
        [NotMapped]
        public MapInfo MapInfo
        {
            get => JsonConvert.DeserializeObject<MapInfo>(_mapInfo); 
            set => _mapInfo = value.ToString();
        }

        public Map()
        {
            Missions = new List<Mission>();
        }
    }
    
    
}
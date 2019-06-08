using System.Collections.Generic;

namespace WebApp.Models
{
    /// <summary>
    /// Contains the map information in database
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Serialized map information
        /// </summary>
        internal string MapInfo { get; private set; }

        public int Id { get; set; }

        /// <summary>
        /// Missions that are using this map
        /// </summary>
        public ICollection<Mission> Missions { get; set; }

        public Map()
        {
            Missions = new List<Mission>();
        }
    }
}
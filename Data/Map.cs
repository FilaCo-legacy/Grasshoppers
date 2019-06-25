using System.Collections.Generic;

namespace Grasshoppers.Data
{
    /// <summary>
    /// Represents the map information in the database
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Serialized map information
        /// </summary>
        public string MapInfo { get; set; }

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
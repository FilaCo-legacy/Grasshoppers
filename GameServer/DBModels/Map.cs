using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameServer.GameCycle;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameServer.DBModels
{
    public class Map
    {
        internal string _mapInfo { get; set; }
        
        public int Id { get; set; }

        [NotMapped]
        public MapInfo MapInfo
        {
            get => JsonConvert.DeserializeObject<MapInfo>(_mapInfo); 
            set => _mapInfo = value.ToString();
        }
    }
    
    
}
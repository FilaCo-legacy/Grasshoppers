using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace GameServer.DBModels
{
    /// <summary>
    /// Class that stores the information about two <see cref="Player"/>'s trade
    /// </summary>
    public class Trade
    {
        /// <summary>
        /// Serialized collection of the first <see cref="Player"/> <see cref="Item"/>s
        /// </summary>
        internal string _firstPlayerItems { get; private set; }

        /// <summary>
        /// Serialized collection of the second <see cref="Player"/> <see cref="Item"/>s
        /// </summary>
        internal string _secondPlayerItems { get; private set; }
        
        public int Id { get; set; }
        
        /// <summary>
        /// A date when this <see cref="Trade"/> happened
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
        
        public int FirstPlayerId { get; set; }
        
        public int SecondPlayerId { get; set; }
        
        [ForeignKey("FirstPlayerId")]
        public Player FirstPlayer { get; set; }
        
        [ForeignKey("SecondPlayerId")]
        public Player SecondPlayer { get; set; }

        /// <summary>
        /// Deserialized collection of the first <see cref="Player"/> <see cref="Item"/>s
        /// </summary>
        [NotMapped]
        public ICollection<Item> FirstPlayerItems
        {
            get => JsonConvert.DeserializeObject<ICollection<Item>>(_firstPlayerItems); 
            set => _firstPlayerItems = value.ToString();
        }

        /// <summary>
        /// Deserialized collection of the second <see cref="Player"/> <see cref="Item"/>s
        /// </summary>
        [NotMapped]
        public ICollection<Item> SecondPlayerItems
        {
            get => JsonConvert.DeserializeObject<ICollection<Item>>(_secondPlayerItems); 
            set => _secondPlayerItems = value.ToString();
        }
    }
}
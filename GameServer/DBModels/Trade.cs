using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace GameServer.DBModels
{
    public class Trade
    {
        internal string _firstPlayerItems;

        internal string _secondPlayerItems;
        
        public int Id { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        public int FirstPlayerId { get; set; }
        
        public int SecondPlayerId { get; set; }
        
        [ForeignKey("FirstPlayerId")]
        public Player FirstPlayer { get; set; }
        
        [ForeignKey("SecondPlayerId")]
        public Player SecondPlayer { get; set; }

        [NotMapped]
        public ICollection<Item> FirstPlayerItems
        {
            get => JsonConvert.DeserializeObject<ICollection<Item>>(_firstPlayerItems); 
            set => _firstPlayerItems = value.ToString();
        }

        [NotMapped]
        public ICollection<Item> SecondPlayerItems
        {
            get => JsonConvert.DeserializeObject<ICollection<Item>>(_secondPlayerItems); 
            set => _secondPlayerItems = value.ToString();
        }
    }
}
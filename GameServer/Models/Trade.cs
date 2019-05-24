using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameServer.Models
{
    public class Trade
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public int FirstPlayerId { get; set; }
        
        public int SecondPlayerId { get; set; }
        
        [ForeignKey("FirstPlayerId")]
        public Player FirstPlayer { get; set; }
        
        [ForeignKey("SecondPlayerId")]
        public Player SecondPlayer { get; set; }
        
        public ICollection<Item> FirstPlayerItems { get; set; }
        
        public ICollection<Item> SecondPlayerItems { get; set; }
    }
}
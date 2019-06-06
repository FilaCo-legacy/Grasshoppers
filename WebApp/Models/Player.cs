using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Player
    { 
        public int Id { get; set; }
        
        [Required, MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        
        [Required]
        public string SpritePath { get; set; }
        
        public ICollection<ItemsPlayers> Inventory { get; set; }

        public Player()
        {
            Inventory = new List<ItemsPlayers>();
        }
    }
}
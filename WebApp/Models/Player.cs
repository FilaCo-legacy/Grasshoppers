using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Player
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public string SpritePath { get; set; }
        
//        public ICollection<Item> Items { get; set; }
//
//        public Player()
//        {
//            Items = new List<Item>();
//        }
    }
}
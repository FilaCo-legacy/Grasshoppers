namespace WebApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public ItemRarity Rarity { get; set; }
        
        public string SpritePath { get; set; }
    }
}
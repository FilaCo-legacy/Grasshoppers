using System.Linq;
using WebApp.Models;

namespace WebApp.SampleData
{
    public static class SampleData
    {
        public static void Initialize(InventoryContext context)
        {
            if (context.Players.Any()) return;
            
            context.Players.AddRange(
                new Player
                {
                    Name = "Vasya",
                    SpritePath = @"Sprites/ManSprite.png"
                },
                new Player
                {
                    Name = "FilaCo",
                    SpritePath = @"Sprites/HeroSprite.png"
                },
                new Player
                {
                    Name = "Singer1077",
                    SpritePath = @"Sprites/ManSprite.png"
                }
            );
            context.SaveChanges();
        }
    }
}
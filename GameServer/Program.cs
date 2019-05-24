using System;
using System.Data.Entity;
using GameServer;
using GameServer.Models;

namespace Tmp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new PlatformerContext("PlatformerDB"))
            {
                var PlayerAppearance1 = new PlayerAppearance
                {
                    BootsColor = 0x0000FF, Gender = GenderValue.Man,
                    HairColor = 0xFF0000, ShirtColor = 0x00FF00, SpritePath = ""
                };
                
                var PlayerAppearance2 = new PlayerAppearance
                {
                    BootsColor = 0x0000FF, Gender = GenderValue.Woman,
                    HairColor = 0xFF0000, ShirtColor = 0x00FF00, SpritePath = ""
                };

                context.PlayerAppearances.Add(PlayerAppearance1);
                context.PlayerAppearances.Add(PlayerAppearance2);

                context.SaveChanges();
                
                var Player1 = new Player{AppearanceId = PlayerAppearance1.Id, Name = "Vasya"};
                var Player2 = new Player {AppearanceId = PlayerAppearance2.Id, Name = "Tanya"};

                context.Players.Add(Player1);
                context.Players.Add(Player2);

                context.SaveChanges();

                foreach (var curPlayer in context.Players)
                {
                    Console.WriteLine($"{curPlayer.Id}:{curPlayer.Name} - {curPlayer.AppearanceId}");
                }
            }
        }
    }
}
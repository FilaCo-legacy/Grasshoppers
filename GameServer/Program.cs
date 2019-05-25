using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GameServer.DBModels;

namespace GameServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new PlatformerContext("PlatformerDB"))
            {
                
            }
        }
    }
}
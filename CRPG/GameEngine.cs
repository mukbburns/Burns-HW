using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public static class GameEngine
    {
        public static string Version = "0.0.2";


        public static void Initialize()
        {
            Console.WriteLine("Initializing Game Engine Version {0}", Version);
            Console.WriteLine("Welcome to {0}", World.WorldName);
            Console.WriteLine();
            //World.ListLocations();
            //world,ListItems();
            //world.ListMonsters();
            //world.ListQuests();

        }


    }
}

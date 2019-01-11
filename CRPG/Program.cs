using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Benjamin Burns 2018
namespace CRPG
{
    class Program
    {
       private static Player _player = new Player("Benji Not Genji",10,10,20,0,1);
       
       
        static void Main(string[] args)
        {
            GameEngine.Initialize();
            _player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
            InventoryItem sword = new InventoryItem (World.ItemByID(World.ITEM_ID_RUSTY_SWORD),1);
            _player.Inventory.Add(sword);
            InventoryItem aPass = new InventoryItem (World.ItemByID(World.ITEM_ID_ADVENTURER_PASS),1);
            _player.Inventory.Add(aPass);
            while(true)
            {
                Console.Write(">");
                string userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    continue;
                }
                string cleanedInput = userInput.ToLower();
                
                if (cleanedInput == "exit")
                {
                    break;
                }
                ParseInput(cleanedInput);
            }//while







            
        }//main
        public static void ParseInput(string input)
        {
            if (input.Contains("help"))
            {
                Console.WriteLine("Help is coming later... stay tuned.");
            } else if (input.Contains("look"))
            {
                DisplayCurrentLocation();
            }
            else if (input.Contains("north")|| input == "n")
            {
                _player.MoveNorth();
            }
            else if (input.Contains("south")|| input == "s")
            {
                _player.MoveSouth();
            }
            else if (input.Contains("east")|| input == "e")
            {
                _player.MoveEast();
            }
            else if (input.Contains("west")|| input == "w")
            {
                _player.MoveWest();
            }
            else if (input.Contains("debug"))
            {
                GameEngine.DebugInfo();
            }
            else if (input == "inventory" || input == "i")
            {
                Console.WriteLine("\n Current Inventory:");
                foreach (InventoryItem invItem in _player.Inventory)
                {
                    Console.WriteLine("\t{0} : {1}",invItem.Details.Name,invItem.Quantity);
                }
            }
            else if (input == "stats")
            {
                Console.WriteLine("\nStats for {0}",_player.Name);
                Console.WriteLine("\tCurrent HP: \t{0}", _player.CurrentHitPoints);
                Console.WriteLine("\tMaximum HP: \t{0}", _player.MaximumHitPoints);
                Console.WriteLine("\tXP: \t\t{0}", _player.ExperiencePoints);
                Console.WriteLine("\tLevel: \t\t{0}",_player.Level);
                Console.WriteLine("\tGold: \t\t{0}",_player.Gold);
                                
                
                
            }
            else
            {
                Console.WriteLine("I don't understand, Sorry!");
            }

        }//par

        public static void DisplayCurrentLocation()
        {
            Console.WriteLine("\nYou are at: {0}", _player.CurrentLocation.Name);
            if(_player.CurrentLocation.Description  != "")
            {
                Console.WriteLine("\t{0}\n", _player.CurrentLocation.Description);

            }

        }
    }
}

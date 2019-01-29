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
            else if (input == "quests" || input == "q")
            {
                
                if(_player.Quests.Count == 0) 
                {
                    Console.WriteLine("You do not have any quests.");
                }else
                {
                    foreach (PlayerQuest playerQuest in _player.Quests)
                    {
                        Console.WriteLine("{0}: {1}", playerQuest.Details.Name,playerQuest.IsCompleted ? "Completed" : "Incomplete");
                    }
                }
            }
            else if (input.Contains("attack") || input == "a")
                {
                    if(_player.CurrentLocation.MonsterLivingHere == null)
                    {
                        Console.WriteLine("There is nothing here to attack");
                    }else
                    {
                        if(_player.CurrentWeapon == null){
                            Console.WriteLine("You are not equipped with a weapon");
                        }else 
                        {
                            _player.UseWeapon(_player.CurrentWeapon);
                        }
                    }
                }else if (input.StartsWith("equip "))
                {
                    _player.UpdateWeapons();
                    string inputWeaponName = input.Substring(6).Trim();
                    if (string.IsNullOrEmpty(inputWeaponName))
                    {
                        Console.WriteLine("You must enter the name of the weapon to equip.");
                    } else 
                    {
                        Weapon weaponToEquip = _player.Weapons.SingleOrDefault( x => x.Name.ToLower() == inputWeaponName
                        || x.NamePlural.ToLower() == inputWeaponName);
                        
                        if(weaponToEquip == null)
                        {
                            Console.WriteLine("You do not have the weapon {0}",inputWeaponName);
                        } else 
                        {
                            _player.CurrentWeapon = weaponToEquip;
                            Console.WriteLine("You equip your {0}",_player.CurrentWeapon.Name);
                        }
                        
                    }
                } else if (input=="weapons")
                {
                    _player.UpdateWeapons();
                    Console.WriteLine("list of Weapons:");
                    foreach (Weapon w in _player.Weapons)
                    {
                        Console.WriteLine("\t{0}",w.Name);
                    }
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

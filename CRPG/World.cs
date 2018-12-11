using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public class World
    {
        public static readonly string WorldName = "Earth #452";
        public static List<Location> Locations = new List<Location>();

        //Start providing IDs for Locations
        public const int Location_ID_HOME = 1;
        public const int Locatioin_ID_Forest_Path = 2;
        public const int Location_ID_Lab = 3;

        //Constructor
        static World()
        {
            PopulateLocations();

        }

        private static void PopulateLocations()
        {
            Location home = new Location(Location_ID_HOME, "Home", "Your house is a mess.");
            Location forestPath = new Location(Locatioin_ID_Forest_Path, "Forest Path", "A wooded path with lots of ferns.");
            Location lab = new Location(Location_ID_Lab, "Lab", "A strange smelling lab with potions and rat tails.");

            home.LocationToNorth = forestPath;
            forestPath.LocationToEast = lab;
            lab.LocationToWest = forestPath;
            forestPath.LocationToSouth = home;


            //Creat our lost of locations
            Locations.Add(home);
            Locations.Add(forestPath);
            Locations.Add(lab);
            

        }


        public static Location LocationByID(int id)
        {
            foreach (Location loc in Locations)
            {
                if (loc.ID == id)
                {
                    return loc;
                }
            }
            return null;
        }

        public static void ListLocations()
        {
            Console.WriteLine("These are the locatoins in the world");
            foreach (Location loc in Locations)
            {
                Console.WriteLine("\t{0}", loc.Name);
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG{
    public class Weapon : Item
    {
        public int MaximumDamage;
        public int MinimumDamage;
        
        public Weapon(int id, string name, string nameplural,int minimumdamage, int maximumdamage):base(id,name,nameplural)
        {
            MaximumDamage = maximumdamage;
            MinimumDamage = minimumdamage;
            
        }
        
    }
}
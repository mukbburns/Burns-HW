using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG{
    public class HealingPotion : Item
    {
        public int AmountToHeal;
        
        public HealingPotion(int iD, string name, string namepural,int amountToHeal):base(iD,name,namepural)
        {
            AmountToHeal = amountToHeal;
            
        }
        
    }
}
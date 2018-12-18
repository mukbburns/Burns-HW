using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG{
    public class LootItem{
         public Item Details;
         public int DropPercentage;
         public bool IsDeafaultItem;
         
         public LootItem(Item details, int dropPercentage,bool isdefaultitem)
         {
             Details = details;
             DropPercentage = dropPercentage;
             IsDeafaultItem = isdefaultitem;
         }
    }
}
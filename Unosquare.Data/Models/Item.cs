using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unosquare.Data.Models
{
    public class Item
    {
        private Random randomID;
        private string itemID = "";
        public string itemType = "";
        public string itemStatus = "";
        //TODO - Create a warehouse
        //public Warehouse warehouse;
        public List<Item> container;

        public Item() 
        {
            //
        }

        public void createItem(
            string typeItem, 
            string statusItem, 
            bool isContainer = false)
        {
            itemID = randomID.Next().ToString();
            itemType = typeItem;
            itemStatus = statusItem;
            if (isContainer) 
            {
                container = new List<Item>();
            }
        }

        }
    }
}

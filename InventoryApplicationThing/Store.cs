using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplicationThing
{
    class Store
    {
        private Dictionary<string, Item> itemList = new Dictionary<string, Item>();
        private string name;
        private string address;
        private int storeNumber;

        public Store(string name, string address, int storeNumber)
        {
            this.name = name;
            this.address = address;
            this.storeNumber = storeNumber;
        }

        public void MakePurchase()
        {
            
        }


        public void AddInventory(string name, Item item)
        {
            itemList.Add(name, item);
        }
    }
}

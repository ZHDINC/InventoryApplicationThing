using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplicationThing
{
    class Transaction
    {
        private DateTimeOffset dateTime;
        private string itemName;
        private int units;
        private decimal totalPurchase;

        public Transaction(string itemName, int units, decimal totalPurchase)
        {
            dateTime = DateTime.Now;
            this.itemName = itemName;
            this.units = units;
            this.totalPurchase = totalPurchase;
        }

        public override string ToString()
        {
            return $"{dateTime} - {itemName} - {units} - ${totalPurchase}";
        }
    }
}

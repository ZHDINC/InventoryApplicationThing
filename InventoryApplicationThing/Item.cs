using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplicationThing
{
    class Item
    {
        private string name;
        private decimal price;
        private int count;
        private bool inStock = true;
        private List<Transaction> transactionLog = new List<Transaction>();

        public Item(string name, decimal price, int count)
        {
            Name = name;
            Price = price;
            ItemCount = count;
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (!(value < 0))
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("We aren't about to pay customers while simultaneously giving the item.");
                }
            }
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int ItemCount
        {
            get => count;
            set
            {
                if(!(value < 0))
                {
                    count = value;
                    if(count == 0)
                    {
                        Console.WriteLine($"{Name} is now out of stock.");
                    }
                }
                else
                {
                    Console.WriteLine("What are we backlogged or something? We can't have negative items!");
                }
            }
        }

        public void CheckStock()
        {
            Console.WriteLine($"Item in stock is: {inStock}. We have {ItemCount} unit(s).");
        }

        public void Restock(int numOfUnits)
        {
            if(numOfUnits <= 0)
            {
                Console.WriteLine("Unable to restock negative or zero units. Returning to menu.");
                return;
            }
            Console.WriteLine($"Restocking {numOfUnits} unit(s) for the item {Name}.");
            ItemCount += numOfUnits;
        }

        public void PurchaseItem()
        {
            if(ItemCount ==  0)
            {
                Console.WriteLine("We are currently out of stock on that item. Returning to main menu.");
                return;
            }
            int quantityDesired;
            while (true)
            {
                Console.Write($"Item: {Name}\nPrice: ${Price}\nInventory: {ItemCount}\nQuantity desired:");
                quantityDesired = int.Parse(Console.ReadLine());
                Console.WriteLine($"You want {quantityDesired}. Is this correct? (y/n)");
                char confirmation = char.Parse(Console.ReadLine());
                if (confirmation == 'y' || confirmation == 'Y') break;
            }
            if(!(quantityDesired > ItemCount))
            {
                ItemCount -= quantityDesired;
                Console.WriteLine($"You purchased {Name} for ${Price * quantityDesired}. Inventory is now {ItemCount}");
                transactionLog.Add(new Transaction(Name, quantityDesired, quantityDesired * Price));
            }
            else
            {
                Console.WriteLine($"Unfortunately, unable to purchase {quantityDesired} {Name}(s) because we only have {ItemCount} in stock. Returning to main menu.");
            }
        }

        public void GetTransactions()
        {
            foreach(Transaction t in transactionLog)
            {
                Console.WriteLine(t);
            }
        }
    }
}

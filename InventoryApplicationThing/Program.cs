using System;

namespace InventoryApplicationThing
{
    class Program
    {
        static void Main(string[] args)
        {
            Item knickKnack = new Item("Graphics Card 9147", 699.99M, 100);
            Store storeTest = new Store("Fictitous Storefront that Sells Everything!", "1234 Makebelieve Way", 1234);
            bool continueLoop = true;
            while(continueLoop)
            {
                //continueLoop = GetSingleItem(knickKnack, continueLoop);
                continueLoop = StoreMenu(storeTest, continueLoop);
            }
        }

        private static bool StoreMenu(Store store, bool continueLoop)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1) Add Inventory 2) Check Inventory 3) PurchaseItem");
            int c = int.Parse(Console.ReadLine());
            switch(c)
            {
                case 1:
                    Console.Write("Enter item name: ");
                    string itemName = Console.ReadLine();
                    Console.Write("Enter price: ");
                    decimal itemPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter inventory: ");
                    int initialInventory = int.Parse(Console.ReadLine());
                    Item newItem = new Item(itemName, itemPrice, initialInventory);
                    store.AddInventory(itemName, newItem);
                    break;
                case 2:
                    Console.WriteLine(store.ShowInventory());
                    break;
                case 3:
                    Console.Write("What do you wish to purchase? ");
                    string desiredItem = Console.ReadLine();
                    store.MakePurchase(desiredItem);
                    break;
                case 4:
                    continueLoop = false;
                    break;
                default:
                    break;
            }
            return continueLoop;
        }

        private static bool GetSingleItem(Item knickKnack, bool continueLoop)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1) Purchase Item 2) Check Inventory 3) Get Transactions 4) Restock");
            int c = int.Parse(Console.ReadLine());
            switch (c)
            {
                case 1:
                    knickKnack.PurchaseItem();
                    break;
                case 2:
                    knickKnack.CheckStock();
                    break;
                case 3:
                    knickKnack.GetTransactions();
                    break;
                case 4:
                    Console.Write("Number of units to restock: ");
                    int quantityToRestock = int.Parse(Console.ReadLine());
                    knickKnack.Restock(quantityToRestock);
                    break;
                case 5:
                    continueLoop = false;
                    break;
                default:
                    break;
            }

            return continueLoop;
        }
    }
}

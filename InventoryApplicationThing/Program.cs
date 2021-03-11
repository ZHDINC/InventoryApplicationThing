using System;

namespace InventoryApplicationThing
{
    class Program
    {
        static void Main(string[] args)
        {
            Item knickKnack = new Item("NVIDIA RTX 3080", 699.99M, 100);
            bool continueLoop = true;
            while(continueLoop)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1) Purchase Item 2) Check Inventory 3) Get Transactions 4) Restock");
                int c = int.Parse(Console.ReadLine());
                switch(c)
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
            }
        }
    }
}

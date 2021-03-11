using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryApplicationThing;
using System.Collections.Generic;
using System;

namespace Inventory.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ItemCreate()
        {
            Item newItem = new Item("Knick-Knack", 699.99M, 100);
            Assert.AreEqual(100, newItem.ItemCount);
            Assert.AreEqual("Knick-Knack", newItem.Name);
            Assert.AreEqual(699.99M, newItem.Price);
        }

        [TestMethod]
        public void TransactionChecker()
        {
            List<Transaction> transactionList = new List<Transaction>();
            transactionList.Add(new Transaction("Knick-knack", 10, (10 * 699.99M)));
            transactionList.Add(new Transaction("Knick-knack", 50, (50 * 699.99M)));
            transactionList.Add(new Transaction("Knick-knack", 17, (17 * 699.99M)));
            Item newItem = new Item("Knick-knack", 699.99M, 100);
            newItem.PurchaseItem(10);
            newItem.PurchaseItem(50);
            newItem.PurchaseItem(17);
            var newItemTransactions = newItem.GetTransactions();
            Assert.AreEqual(transactionList[0].ToString(), newItemTransactions[0].ToString());
            Assert.AreEqual(transactionList[1].ToString(), newItemTransactions[1].ToString());
            Assert.AreEqual(transactionList[2].ToString(), newItemTransactions[2].ToString());
        }

        [TestMethod]
        public void InventoryCountTracker()
        {
            Item newItem = new Item("Knick-Knack", 19.99M, 100);
            newItem.PurchaseItem(11);
            newItem.PurchaseItem(22);
            newItem.PurchaseItem(33);
            newItem.Restock(100);
            newItem.Restock(50);
            Assert.AreEqual(184, newItem.ItemCount);
        }
    }
}

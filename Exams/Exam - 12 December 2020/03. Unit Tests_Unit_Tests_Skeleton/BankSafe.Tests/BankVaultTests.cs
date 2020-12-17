using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        Item item;
        BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            item = new Item("owner", "10");
            bankVault = new BankVault();
        }

        [Test]
        public void ItemConstructor_ShouldWorkProperly()
        {
            Assert.AreEqual("owner", item.Owner);
            Assert.AreEqual("10", item.ItemId);
        }

        [Test]
        public void BankVaultConstructor_ShouldWorkProperly()
        {
            Assert.AreEqual(12, bankVault.VaultCells.Count);
        }

        [Test]
        public void AddItemMethod_ShouldThrowEx_WhenAddingToInvalidCell()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A5", item));
        }

        [Test]
        public void AddItemMethod_ShouldThrowEx_WhenAddingToNonFreeCell()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", new Item("owner2", "11")));
        }

        [Test]
        public void AddItemMethod_ShouldThrowEx_WhenAddingToSameFreeCell()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }

        [Test]
        public void AddItemMethod_ShouldWorkProperly()
        {
            bankVault.AddItem("A1", item);
            Assert.AreEqual(item, bankVault.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItemMethod_ShouldThrowEx_WithNonExistingCell()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A5", item));
        }

        [Test]
        public void RemoveItemMethod_ShouldThrowEx_WithNonExistingItem()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item));
        }

        [Test]
        public void RemoveItemMethod_ShouldWorkProperly()
        {
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);
            Assert.AreEqual(null, bankVault.VaultCells["A1"]);
        }
    }
}
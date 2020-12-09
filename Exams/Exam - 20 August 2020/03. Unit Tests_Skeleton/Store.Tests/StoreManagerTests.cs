using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private Product product;
        private StoreManager storeManager;
        private List<Product> products;

        [SetUp]
        public void Setup()
        {
            product = new Product("name", 1, 1);
            storeManager = new StoreManager();
            products = new List<Product>();
        }

        [Test]
        public void ProductConstructor_ShouldWorkProperly()
        {
            Assert.AreEqual(product.Name, "name");
            Assert.AreEqual(product.Quantity, 1);
            Assert.AreEqual(product.Price, 1);
        }

        [Test]
        public void StoreManagerCount_ShouldWorkProperly()
        {
            storeManager.AddProduct(product);
            Assert.AreEqual(storeManager.Count, 1);
        }

        [Test]
        public void ProductsProperty_ShouldWorkProperly()
        {
            Product product2 = new Product("name2", 2, 5);
            storeManager.AddProduct(product);
            storeManager.AddProduct(product2);
            products.Add(product);
            products.Add(product2);
            Assert.AreEqual(products.AsReadOnly(), storeManager.Products);
        }

        [Test]
        public void AddMethod_ShouldThrowEx_WithNullProduct()
        {
            product = null;
            Assert.Throws<ArgumentNullException>(() => { storeManager.AddProduct(product); });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void AddMethod_ShouldThrowEx_WithInvalidProductQuantity(int quantity)
        {
            product = new Product("name", quantity, 2);
            Assert.Throws<ArgumentException>(() => { storeManager.AddProduct(product); });
        }

        [Test]
        public void BuyMethod_ShouldThrowEx_WithNullProduct()
        {
            Assert.Throws<ArgumentNullException>(() => { storeManager.BuyProduct("no name", 2); });
        }

        [Test]
        public void BuyMethod_ShouldThrowEx_WithFewerQuantity()
        {
            product = new Product("name2", 5, 5);
            storeManager.AddProduct(product);
            Assert.Throws<ArgumentException>(() => { storeManager.BuyProduct("name2", 10); });
        }

        [Test]
        public void BuyMethod_ShouldWorkProperly()
        {
            product = new Product("name2", 10, 10);
            storeManager.AddProduct(product);
            Assert.AreEqual(50, storeManager.BuyProduct("name2", 5));
            Assert.AreEqual(5, product.Quantity);
        }

        [Test]
        public void MostExpensiveProductMethod_ShouldWorkProperly()
        {
            Product product2 = new Product("name2", 5, 5);
            storeManager.AddProduct(product);
            storeManager.AddProduct(product2);
            Assert.AreEqual(product2, storeManager.GetTheMostExpensiveProduct());
        }
    }
}
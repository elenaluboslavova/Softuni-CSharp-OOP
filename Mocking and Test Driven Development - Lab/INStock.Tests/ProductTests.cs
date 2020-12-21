namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ProductTests
    {
        private IProduct product;
        private IProductStock products;

        [SetUp]
        public void SetUp()
        {
            product = new Product("label", 10, 10);
            products = new ProductStock();
        }

        [Test]
        public void ProductConstructor_ShouldWorkProperly()
        {
            Assert.AreEqual("label", product.Label);
            Assert.AreEqual(10, product.Price);
            Assert.AreEqual(10, product.Quantity);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void ProductPropertyLabel_ShouldThrowEx_WithNullOrWhiteSpaceValue(string label)
        {
            Assert.Throws<ArgumentException>(() => product = new Product(label, 10, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void ProductPropertyPrice_ShouldThrowEx_WithValueLessOrEqualToZero(decimal price)
        {
            Assert.Throws<ArgumentException>(() => product = new Product("label", price, 10));
        }

        [Test]
        public void ProductPropertyQuantity_ShouldThrowEx_WithValueLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => product = new Product("label", 10, -10));
        }

        [Test]
        public void ProductCompareToMethod_ShouldWorkProperly()
        {
            IProduct product2 = new Product("label2", 1, 1);
            IProduct product3 = new Product("label3", 10, 10);
            IProduct product4 = new Product("label4", 20, 10);

            Assert.AreEqual(1, product.CompareTo(product2));
            Assert.AreEqual(0, product.CompareTo(product3));
            Assert.AreEqual(-1, product.CompareTo(product4));
        }

        [Test]
        public void AddMethod_ShouldWorkProperly()
        {
            Assert.AreEqual(0, products.Count);
            products.Add(product);
            Assert.AreEqual(1, products.Count);
            products.Add(product);
            Assert.AreEqual(1, products.Count);
        }

        [Test]
        public void ContainsMethod_ShouldWorkProperly()
        {
            products.Add(product);
            IProduct product2 = new Product("label2", 10, 10);

            Assert.AreEqual(true, products.Contains(product));
            Assert.AreEqual(false, products.Contains(product2));
        }

        [Test]
        [TestCase(-5)]
        [TestCase(5)]
        public void FindMethod_ShouldThrowEx_WithInvalidIndex(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => products.Find(index));
        }

        [Test]
        public void FindMethod_ShouldWorkProperly()
        {
            products.Add(product);
            Assert.AreEqual(product, products.Find(0));
        }

        [Test]
        public void FindAllByPriceMethod_ShouldWorkProperly()
        {
            IProduct product2 = new Product("label2", 10, 10);
            IProduct product3 = new Product("label3", 5, 5);

            products.Add(product);
            products.Add(product2);
            products.Add(product3);

            List<IProduct> list = new List<IProduct>
            {
                product,
                product2
            };

            Assert.AreEqual(list, products.FindAllByPrice(10));
        }

        [Test]
        public void FindAllInPriceRangeMethod_ShouldWorkProperly()
        {
            IProduct product2 = new Product("label2", 15, 10);
            IProduct product3 = new Product("label3", 5, 5);

            products.Add(product);
            products.Add(product2);
            products.Add(product3);

            List<IProduct> list = new List<IProduct>
            {
                product2,
                product
            };

            Assert.AreEqual(list, products.FindAllInPriceRange(10, 15));
        }

        [Test]
        public void FindByLabelMethod_ShouldThrowEx_WithNullProduct()
        {
            Assert.Throws<ArgumentException>(() => products.FindByLabel("label5"));
        }

        [Test]
        public void FindByLabelMethod_ShouldWorkProperly()
        {
            products.Add(product);
            Assert.AreEqual(product, products.FindByLabel("label"));
        }

        [Test]
        public void FindMostExpensiveProductMethod_ShouldWorkProperly()
        {
            IProduct product2 = new Product("label2", 50, 10);
            products.Add(product2);
            IProductStock products2 = new ProductStock();

            Assert.AreEqual(product2, products.FindMostExpensiveProduct());
            Assert.AreEqual(null, products2.FindMostExpensiveProduct());
        }
    }
}
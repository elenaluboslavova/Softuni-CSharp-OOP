namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ComputerTests
    {
        private Part part;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            part = new Part("part", 10);
            computer = new Computer("computer");
        }

        [Test]
        public void PartConstructor_ShouldWorkProperly()
        {
            Assert.AreEqual("part", part.Name);
            Assert.AreEqual(10, part.Price);
        }

        [Test]
        public void ComputerConstructor_ShouldWorkProperly()
        {
            List<Part> parts = new List<Part>();

            Assert.AreEqual("computer", computer.Name);
            Assert.AreEqual(parts, computer.Parts);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NameProperty_ShouldThrowEx_WithNullOrWhiteSpaceValue(string name)
        {
            Assert.Throws<ArgumentNullException>(() => computer = new Computer(name));
        }

        [Test]
        public void TotalPriceProperty_ShouldWorkProperly()
        {
            Part part2 = new Part("part2", 20);
            computer.AddPart(part);
            computer.AddPart(part2);
            Assert.AreEqual(30, computer.TotalPrice);
        }

        [Test]
        public void AddPartMethod_ShouldThrowEx_WithNullPart()
        {
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]
        public void RemovePartMethod_ShouldWorkProperly()
        {
            computer.AddPart(part);
            Assert.AreEqual(1, computer.Parts.Count);
            computer.RemovePart(part);
            Assert.AreEqual(0, computer.Parts.Count);
        }

        [Test]
        public void GetPartMethod_ShouldWorkProperly()
        {
            computer.AddPart(part);
            Assert.AreEqual(part, computer.GetPart("part"));
        }
    }
}
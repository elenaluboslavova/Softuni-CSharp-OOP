using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("model", 10, 10);
            driver = new UnitDriver("name", car);
            raceEntry = new RaceEntry();
        }

        [Category("Driver")]
        [Test]
        public void DriverConstructor_ShouldWorkProperly()
        {
            Assert.AreEqual(driver.Name, "name");
            Assert.AreEqual(car.Model, "model");
            Assert.AreEqual(car.HorsePower, 10);
            Assert.AreEqual(car.CubicCentimeters, 10);
        }

        [Category("Driver")]
        [Test]
        public void DriverConstructor_ShouldThrowException_WithNullName()
        {
            Assert.Throws<ArgumentNullException>(() => { driver = new UnitDriver(null, car); });
        }

        [Category("RaceEntry")]
        [Test]
        public void RaceEntryCount_ShouldWorkProperly()
        {
            Assert.AreEqual(raceEntry.Counter, 0);
            raceEntry.AddDriver(driver);
            Assert.AreEqual(raceEntry.Counter, 1);
        }

        [Category("RaceEntry")]
        [Test]
        public void AddDriverMethod_ShouldThrowEx_WithNullDriver()
        {
            Assert.Throws<InvalidOperationException>(() => { raceEntry.AddDriver(null); });
        }

        [Category("RaceEntry")]
        [Test]
        public void AddDriverMethod_ShouldThrowEx_WithExistingDriver()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => { raceEntry.AddDriver(driver); });
        }

        [Category("RaceEntry")]
        [Test]
        public void CalculateAverageHorsePowerMethod_ShouldThrowEx_WithInvalidParticipants()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Category("RaceEntry")]
        [Test]
        public void CalculateAverageHorsePowerMethod_ShouldWorkProperly()
        {
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(new UnitDriver("name2", new UnitCar("model2", 20, 20)));
            Assert.AreEqual(raceEntry.CalculateAverageHorsePower(), 15);
        }
    }
}
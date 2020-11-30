using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("make", "model", 10, 10)]
        public void CarConstructorShouldWorkProperly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
        }

        [Test]
        [TestCase(null, "model", 10, 10)]
        [TestCase("", "model", 10, 10)]
        public void MakePropertyShouldThrowExceptionWithNullOrEmptyMake(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("make", null, 10, 10)]
        [TestCase("make", "", 10, 10)]
        public void ModelPropertyShouldThrowExceptionWithNullOrEmptyModel(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("make", "model", 0, 10)]
        [TestCase("make", "model", -5, 10)]
        public void FuelConsumptionPropertyShouldThrowExceptionWithFuelConsumptionBelowOrEqualToZero(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("make", "model", 10, 0)]
        [TestCase("make", "model", 10, -5)]
        public void FuelCapacityPropertyShouldThrowExceptionWithFuelCapacityBelowOrEqualToZero(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void RefuelMethodShouldThrowExceptionWhenRefuelingWithFuelBelowOrEqualToZero(double fuel)
        {
            Car car = new Car("make", "model", 10, 10);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void RefuelMethodShouldRefuelProperly()
        {
            Car car = new Car("make", "model", 10, 10);

            car.Refuel(5);

            var expectedResult = 5;
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FefuelMethodShouldWorkProperly()
        {
            Car car = new Car("make", "model", 10, 10);

            car.Refuel(15);

            var expectedResult = 10;
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionWhenFuelIsNotEnough()
        {
            Car car = new Car("make", "model", 10, 10);

            car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() => car.Drive(110));
        }

        [Test]
        public void DriveMethodShouldWorkProperly()
        {
            Car car = new Car("make", "model", 10, 10);

            car.Refuel(10);
            car.Drive(50);

            var expectedResult = 5;
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
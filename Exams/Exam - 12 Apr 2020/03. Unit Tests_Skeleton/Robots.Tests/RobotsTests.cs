namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    
    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Test", 10);
            manager = new RobotManager(10);
        }

        [Test]
        public void WhenRobotIsCreated_PropertiesShouldBeSet()
        {
            Assert.AreEqual("Test", robot.Name);
            Assert.AreEqual(10, robot.Battery);
            Assert.AreEqual(10, robot.MaximumBattery);
        }

        [Test]
        public void WhenRobotManagerIsCreated_CapacityShouldBeSet()
        {
            Assert.AreEqual(10, manager.Capacity);
        }

        [Test]
        public void WhenRobotManagerIsCreated_CountShouldBeZero()
        {
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void WhenRobotManagerCapacityIsNegative_ExceptionShouldBeThrown()
        {
            Assert.Throws<ArgumentException>(() => 
            { 
                RobotManager robotManager = new RobotManager(-5); 
            });
        }

        [Test]
        public void WhenAddingSameRobots_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot);
                manager.Add(robot);
            });
        }

        [Test]
        public void WhenAddingWithoutCapacity_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager robotManager = new RobotManager(1);
                robotManager.Add(robot);
                robotManager.Add(new Robot("Test2", 10));
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager robotManager = new RobotManager(0);
                robotManager.Add(robot);
            });
        }

        [Test]
        public void WhenAddingCorrectData_ShouldWork()
        {
            manager.Add(robot);
            Assert.AreEqual(1, manager.Count);
            manager.Add(new Robot("name", 5));
            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void WhenRemovingNotExistingRobot_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("no name");
            });
        }

        [Test]
        public void WhenRemovingExistingRobot_ShouldRemoveCorrectly()
        {
            manager.Add(new Robot("name", 2));
            manager.Remove("name");
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void WhenWorkNotExistingRobot_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("no name", "job", 10);
            });
        }

        [Test]
        public void WhenWorkNotChargedRobot_ExceptionShouldBeThrown()
        {
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work(robot.Name, "job", robot.Battery + 10);
            });
        }

        [Test]
        public void WhenWorkChargedRobot_ShouldDecreaseBattery()
        {
            manager.Add(robot);
            manager.Work(robot.Name, "job", 5);

            Assert.AreEqual(robot.Battery, 5);
        }

        [Test]
        public void WhenChargeNotExistingRobot_ExceptionShouldBeThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("no name");
            });
        }

        [Test]
        public void WhenChargeRobot_ShouldGetBatteryToMaximum()
        {
            manager.Add(robot);
            manager.Work(robot.Name, "job", 5);
            manager.Charge(robot.Name);
            Assert.AreEqual(robot.Battery, 10);
        }
    }
}

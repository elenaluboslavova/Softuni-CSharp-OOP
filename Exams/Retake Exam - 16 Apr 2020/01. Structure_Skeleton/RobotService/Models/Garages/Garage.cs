using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int capacity = 10;
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => robots;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count == capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (this.robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException($"Robot {robot.Name} already exist");
            }
            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot currentRobot = this.robots.Values.FirstOrDefault(r => r.Name == robotName);
            currentRobot.Owner = ownerName;
            currentRobot.IsBought = true;
            this.robots.Remove(currentRobot.Name);
        }
    }
}

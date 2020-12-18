using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        private List<IProcedure> procedures;
        private Chip chip;
        private Charge charge;
        private Polish polish;
        private Rest rest;
        private TechCheck techCheck;
        private Work work;

        public Controller()
        {
            garage = new Garage();
            procedures = new List<IProcedure>();
            chip = new Chip();
            charge = new Charge();
            polish = new Polish();
            rest = new Rest();
            techCheck = new TechCheck();
            work = new Work();
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = garage.Robots.Values.FirstOrDefault(r => r.Name == robotName);
            charge.DoService(robot, procedureTime);
            if (!procedures.Contains(charge))
            {
                procedures.Add(charge);
            }
            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = garage.Robots.Values.FirstOrDefault(r => r.Name == robotName);
            chip.DoService(robot, procedureTime);
            if (!procedures.Contains(chip))
            {
                procedures.Add(chip);
            }
            return $"{robotName} had chip procedure";
        }

        public string History(string procedureType)
        {
            IProcedure currentProcedure = procedures.FirstOrDefault(p => p.GetType().Name == procedureType);
            return currentProcedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == robotType);
            if (type == null)
            {
                throw new ArgumentException($"{robotType} type doesn't exist");
            }
            IRobot robot = CreateRobot(robotType, name, energy, happiness, procedureTime);
            garage.Manufacture(robot);
            return $"Robot {name} registered successfully";
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = garage.Robots.Values.FirstOrDefault(r => r.Name == robotName);
            polish.DoService(robot, procedureTime);
            if (!procedures.Contains(polish))
            {
                procedures.Add(polish);
            }
            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = garage.Robots.Values.FirstOrDefault(r => r.Name == robotName);
            rest.DoService(robot, procedureTime);
            if (!procedures.Contains(rest))
            {
                procedures.Add(rest);
            }
            return $"{robotName} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = garage.Robots.Values.FirstOrDefault(r => r.Name == robotName);
            garage.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = garage.Robots.Values.FirstOrDefault(r => r.Name == robotName);
            techCheck.DoService(robot, procedureTime);
            if (!procedures.Contains(techCheck))
            {
                procedures.Add(techCheck);
            }
            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = garage.Robots.Values.FirstOrDefault(r => r.Name == robotName);
            work.DoService(robot, procedureTime);
            if (!procedures.Contains(work))
            {
                procedures.Add(work);
            }
            return $"{robotName} was working for {procedureTime} hours";
        }

        private IRobot CreateRobot(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;
            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            return robot;
        }
    }
}

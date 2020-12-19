using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using IComponent = OnlineShop.Models.Products.Components.IComponent;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(c => c.Name == componentType);
            if (type == null)
            {
                throw new ArgumentException("Component type is invalid.");
            }
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            IComponent component = (IComponent)Activator.CreateInstance(type, new object[] { id, manufacturer, model, price, overallPerformance, generation });
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            computer.AddComponent(component);
            this.components.Add(component);
            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(c => c.Name == computerType);
            if (type == null)
            {
                throw new ArgumentException("Computer type is invalid.");
            }
            IComputer instance = (IComputer)Activator.CreateInstance(type, new object[] { id, manufacturer, model, price });
            this.computers.Add(instance);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (this.peripherals.Any(c => c.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(c => c.Name == peripheralType);
            if (type == null)
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            IPeripheral instance = (IPeripheral)Activator.CreateInstance(type, new object[] { id, manufacturer, model, price, overallPerformance, connectionType });
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            computer.AddPeripheral(instance);
            this.peripherals.Add(instance);
            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            this.computers = this.computers.OrderByDescending(c => c.OverallPerformance).ThenBy(c => c.Price).ToList();
            IComputer computer = this.computers[0];
            if (computer.Price > budget)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            IComponent component = computer.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            int id = component.Id;
            computer.Components.ToList().Remove(component);
            this.components.Remove(component);
            return $"Successfully removed {componentType} with id {id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            IPeripheral peripheral = computer.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            int id = peripheral.Id;
            computer.Peripherals.ToList().Remove(peripheral);
            this.peripherals.Remove(peripheral);
            return $"Successfully removed {peripheralType} with id {id}.";
        }
    }
}

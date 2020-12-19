using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        private double overallPerformance;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            this.overallPerformance = overallPerformance;
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                {
                    return this.overallPerformance;
                }
                else
                {
                    double average = 0;
                    foreach (var item in this.components)
                    {
                        average += item.OverallPerformance;
                    }
                    average /= components.Count;
                    return this.overallPerformance + average;
                }
            }
        }

        public override decimal Price
        {
            get
            {
                decimal sum = 0;
                foreach (var item in this.components)
                {
                    sum += item.Price;
                }
                foreach (var item in this.peripherals)
                {
                    sum += item.Price;
                }
                return sum + this.Price;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components({this.components.Count}):");
            foreach (var item in this.components)
            {
                sb.AppendLine("  " + item.ToString());
            }
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({OverallPerformance - this.overallPerformance}):");
            foreach (var item in this.peripherals)
            {
                sb.AppendLine("  " + item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || !this.components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            IComponent componentToRemove = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(this.components.FirstOrDefault(c => c.GetType().Name == componentType));
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || !this.peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            IPeripheral peripheralToRemove = this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            this.peripherals.Remove(this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType));
            return peripheralToRemove;
        }
    }
}

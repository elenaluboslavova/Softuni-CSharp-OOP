using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Pizza_Calories
{
    public class Topping
    {
        private string type;
        private double weight;
        private double modifier;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
            if (this.Type.ToLower() == "meat")
            {
                this.Modifier = 1.2;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                this.Modifier = 0.8;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                this.Modifier = 1.1;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                this.Modifier = 0.9;
            }
        }
        public string Type 
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    Console.WriteLine($"Cannot place {value} on top of your pizza.");
                    Environment.Exit(0);
                }
                this.type = value;
            }
        }
        public double Weight 
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    Console.WriteLine($"{this.Type} weight should be in the range [1..50].");
                    Environment.Exit(0);
                }
                this.weight = value;
            }
        }
        public double Modifier { get; set; }
        public double CalculateToppingCalories()
        {
            double calories = 2.00 * Weight * Modifier;
            return calories;
        }
    }
}

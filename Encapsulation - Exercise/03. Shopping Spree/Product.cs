using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Shopping_Spree
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }
                this.name = value;
            } 
        }

        public double Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
                this.cost = value;
            }
        }
    }
}

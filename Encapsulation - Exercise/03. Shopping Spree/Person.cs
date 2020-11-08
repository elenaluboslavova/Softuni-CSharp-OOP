using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Shopping_Spree
{
    public class Person
    {
        private string name;
        private double money;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }
                this.name = value;
            }
        }

        public double Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
                this.money = value;
            }
        }
        public List<Product> Products { get; set; }
    }
}

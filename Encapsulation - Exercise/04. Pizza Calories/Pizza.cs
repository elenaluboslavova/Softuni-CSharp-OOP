using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Pizza_Calories
{
    public class Pizza
    {
        private string name;

        public Pizza(string name, List<Topping> toppings, Dough dough)
        {
            this.Name = name;
            this.Toppings = toppings;
            this.Dough = dough;
        }
        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(0);
                }
                this.name = value;
            }
        }
        public List<Topping> Toppings { get; set; }
        public Dough Dough { get; set; }

        public double CalculatePizzaCalories()
        {
            double calories = 0;
            foreach (var topping in Toppings)
            {
                calories += topping.CalculateToppingCalories();
            }
            calories += Dough.CalculateDoughCalories();
            return calories;
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count > 10)
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
                Environment.Exit(0);
            }
            Toppings.Add(topping);
        }
    }
}

using System;
using System.Collections.Generic;

namespace _04._Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughInfo = Console.ReadLine().Split();
            string flourType = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            double grams = double.Parse(doughInfo[3]);

            Dough dough = new Dough(flourType, bakingTechnique, grams);

            Pizza pizza = new Pizza(pizzaName, new List<Topping>(), dough);

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] toppingsInfo = command.Split();
                string type = toppingsInfo[1];
                double weight = double.Parse(toppingsInfo[2]);

                Topping topping = new Topping(type, weight);
                pizza.AddTopping(topping);
                
                command = Console.ReadLine();
            }

            Console.WriteLine($"{pizza.Name} - {pizza.CalculatePizzaCalories():F2} Calories.");
        }
    }
}

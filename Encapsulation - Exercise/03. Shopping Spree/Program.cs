using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shopping_Spree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] peopleInfo = Console.ReadLine().Split(";");
            for (int i = 0; i < peopleInfo.Length; i++)
            {
                if (peopleInfo[i] == "")
                {
                    continue;
                }
                string[] personInfo = peopleInfo[i].Split("=");
                string name = personInfo[0];
                double money = double.Parse(personInfo[1]);
                Person person = new Person(name, money);
                people.Add(person);
            }

            List<Product> products = new List<Product>();
            string[] productsInfo = Console.ReadLine().Split(";");
            for (int i = 0; i < productsInfo.Length; i++)
            {
                if (productsInfo[i] == "")
                {
                    continue;
                }
                string[] productInfo = productsInfo[i].Split("=");
                string name = productInfo[0];
                double cost = double.Parse(productInfo[1]);
                Product product = new Product(name, cost);
                products.Add(product);
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string person = command.Split()[0];
                string product = command.Split()[1];

                Person currentPerson = null; ;
                foreach (var p in people)
                {
                    if (p.Name == person)
                    {
                        currentPerson = p;
                    }
                }

                Product currentProduct = null;
                foreach (var pr in products)
                {
                    if (pr.Name == product)
                    {
                        currentProduct = pr;
                    }
                }

                if (currentPerson.Money >= currentProduct.Cost)
                {
                    currentPerson.Products.Add(currentProduct);
                    currentPerson.Money -= currentProduct.Cost;
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                }

                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (person.Products.Count > 0)
                {
                    List<string> prod = new List<string>();
                    foreach (var pr in person.Products)
                    {
                        prod.Add(pr.Name);
                    }
                    Console.WriteLine($"{person.Name} - {string.Join(", ", prod)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}

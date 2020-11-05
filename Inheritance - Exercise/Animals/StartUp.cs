using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string animalType = Console.ReadLine();
            while (animalType != "Beast!")
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];

                if (animalType == "Cat")
                {
                    Cat cat = new Cat(name,age,gender);
                    animals.Add(cat);
                }
                else if (animalType == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (animalType == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                }
                else if (animalType == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }
                else if (animalType == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                }

                animalType = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}

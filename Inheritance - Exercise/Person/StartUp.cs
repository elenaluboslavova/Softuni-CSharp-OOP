﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class StartUp
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person;
            if (age <= 15)
            {
                person = new Child(name, age);
            }
            else
            {
                person = new Person(name, age);
            }
            
            Console.WriteLine(person);
        }
    }
}

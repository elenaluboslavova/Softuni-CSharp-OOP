using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Border_Control
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IByuer> buyers = new List<IByuer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    buyers.Add(rebel);
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                foreach (var buyer in buyers)
                {
                    if (buyer.Name == command)
                    {
                        buyer.BuyFood();
                    }
                }

                command = Console.ReadLine();
            }

            int totalFood = 0;
            foreach (var buyer in buyers)
            {
                totalFood += buyer.Food;
            }
            Console.WriteLine(totalFood);

            //string input = Console.ReadLine();
            //List<IBirthable> list = new List<IBirthable>();

            //while (input != "End")
            //{
            //    string[] inputSplitted = input.Split();
            //    if (inputSplitted[0] == "Citizen")
            //    {
            //        string name = inputSplitted[1];
            //        int age = int.Parse(inputSplitted[2]);
            //        string id = inputSplitted[3];
            //        string birthdate = inputSplitted[4];
            //        Citizen citizen = new Citizen(name, age, id, birthdate);
            //        list.Add(citizen);
            //    }
            //    else if(inputSplitted[0] == "Pet")
            //    {
            //        string name = inputSplitted[1];
            //        string birthdate = inputSplitted[2];
            //        Pet pet = new Pet(name, birthdate);
            //        list.Add(pet);
            //    }

            //    input = Console.ReadLine();
            //}

            //string year = Console.ReadLine();
            //Console.WriteLine(HasYear(list, year));
        }

        //public static string HasYear(List<IBirthable> list, string year)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in list)
        //    {
        //        int counter = 0;
        //        for (int i = year.Length - 1; i >= 0; i--)
        //        {
        //            if (item.Birthdate[item.Birthdate.Length - year.Length + i] == year[i])
        //            {
        //                counter++;
        //            }
        //        }
        //        if (counter == year.Length)
        //        {
        //            sb.AppendLine(item.Birthdate);
        //        }
        //    }
        //    return sb.ToString().TrimEnd();
        //}
    }
}

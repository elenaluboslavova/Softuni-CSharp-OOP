using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            int n = int.Parse(Console.ReadLine());
            BaseHero hero = null;
            List<BaseHero> heroes = new List<BaseHero>();
            int lines = 0;
            while (lines != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == heroType);
                if (type == null)
                {
                    Console.WriteLine("Invalid hero!");
                }
                else if(heroType == "Druid")
                {
                    hero = new Druid(heroName);
                    heroes.Add(hero);
                    lines++;
                }
                else if (heroType == "Paladin")
                {
                    hero = new Paladin(heroName);
                    heroes.Add(hero);
                    lines++;
                }
                else if (heroType == "Rogue")
                {
                    hero = new Rogue(heroName);
                    heroes.Add(hero);
                    lines++;
                }
                else if (heroType == "Warrior")
                {
                    hero = new Warrior(heroName);
                    heroes.Add(hero);
                    lines++;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int neededPower = 0;
            if (heroes.Count > 0)
            {
                foreach (var h in heroes)
                {
                    Console.WriteLine(h.CastAbility());
                    neededPower += h.Power;
                }
                if (neededPower >= bossPower)
                {
                    Console.WriteLine("Victory!");
                }
                else
                {
                    Console.WriteLine("Defeat...");
                }
            }
            
        }
    }
}

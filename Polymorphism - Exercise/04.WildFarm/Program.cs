using _04.WildFarm.Core;
using _04.WildFarm.Core.Contracts;
using _04.WildFarm.Models;
using System;
using System.Linq;

namespace _04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

using System;

namespace _05._Convert_To_Double
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            try
            {
                var number = Convert.ToDouble(input);
                Console.WriteLine(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
                throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
                throw;
            }
        }
    }
}

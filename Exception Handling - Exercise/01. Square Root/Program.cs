using System;

namespace _01._Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}

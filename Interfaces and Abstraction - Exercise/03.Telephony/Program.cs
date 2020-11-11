using _03.Telephony.Exceptions;
using System;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbersToCall = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartPhone = new Smartphone();

            for (int i = 0; i < numbersToCall.Length; i++)
            {
                try
                {
                    if (numbersToCall[i].Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(numbersToCall[i]));
                    }
                    else if (numbersToCall[i].Length == 10)
                    {
                        Console.WriteLine(smartPhone.Call(numbersToCall[i]));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(urls[i]));
                }
                catch (InvalidURLException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

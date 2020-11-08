﻿using System;

namespace _01._Class_Box_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = new Box(length, width, height);

            Console.WriteLine(box.GetSurfaceArea(box));
            Console.WriteLine(box.GetLateralSurfaceArea(box));
            Console.WriteLine(box.GetVolume(box));
        }
    }
}

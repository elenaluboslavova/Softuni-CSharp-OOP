using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Class_Box_Data
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    Environment.Exit(0);
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    Environment.Exit(0);
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    Environment.Exit(0);
                }
                this.height = value;
            }
        }

        public string GetSurfaceArea(Box box)
        {
            double surfaceArea = 2 * box.length * box.width + 2 * box.length * box.height + 2 * box.width * box.height;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Surface Area - {surfaceArea:F2}");
            return sb.ToString().TrimEnd();
        }

        public string GetLateralSurfaceArea(Box box)
        {
            double lateralSurfaceArea = 2 * box.length * box.height + 2 * box.width * box.height;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Lateral Surface Area - {lateralSurfaceArea:F2}");
            return sb.ToString().TrimEnd();
        }

        public string GetVolume(Box box)
        {
            double volume = box.length * box.width * box.height;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Volume - {volume:F2}");
            return sb.ToString().TrimEnd();
        }
    }
}

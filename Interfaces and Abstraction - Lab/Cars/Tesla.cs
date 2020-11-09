using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar, ICar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Battery { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString().TrimEnd();
        }

        public string Start()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Engine start");
            return sb.ToString().TrimEnd();
        }

        public string Stop()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Breaaak!");
            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} Seat {Model}");
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

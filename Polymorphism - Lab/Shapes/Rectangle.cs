using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private readonly double height;
        private readonly double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.width + this.height);
        }
        public override string Draw()
        {
            return base.Draw() + " " + this.GetType().Name;
        }
    }
}

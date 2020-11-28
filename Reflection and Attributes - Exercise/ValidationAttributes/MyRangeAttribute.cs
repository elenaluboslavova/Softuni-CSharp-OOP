using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int min;
        private int max;

        public MyRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new InvalidOperationException();
            }

            int value = (int)obj;

            bool result = value >= min && value <= max;

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Border_Control
{
    public interface IByuer
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public void BuyFood();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Border_Control
{
    public class Robot : IId
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Model { get; set; }
        public string Id { get; set; }
    }
}

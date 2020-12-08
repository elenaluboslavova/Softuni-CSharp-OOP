using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.CubicCentimeters = cubicCentimeters;
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 4));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public int MinHorsePower { get; set; }

        public int MaxHorsePower { get; set; }

        public double CubicCentimeters { get; set; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / horsePower * laps;
        }
    }
}

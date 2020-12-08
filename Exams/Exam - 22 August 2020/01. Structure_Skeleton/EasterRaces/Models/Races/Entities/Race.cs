using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.laps;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers
        {
            get
            {
                return this.drivers.AsReadOnly();
            }
            set
            {
                this.drivers = new List<IDriver>();
            }
        }

        public void AddDriver(IDriver driver)
        {
            if (isValid(driver))
            {
                drivers.Add(driver);
            }
        }

        private bool isValid(IDriver driver)
        {
            if (driver == null)
            {
                return false;
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            else if (!driver.CanParticipate)
            {
                return false;
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            else if (drivers.Contains(driver))
            {
                return false;
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverNotFound, driver.Name));
            }
            return true;
        }
    }
}

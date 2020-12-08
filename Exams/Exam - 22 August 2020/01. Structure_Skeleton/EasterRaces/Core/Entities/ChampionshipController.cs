using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository carRepository;
        private readonly DriverRepository driverRepository;
        private readonly RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (carRepository.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            IDriver driver = new Driver(driverName);
            ICar car = carRepository.GetByName(carModel);
            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            IRace race = raceRepository.GetByName(raceName);
            if (driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            IDriver driver = driverRepository.GetByName(driverName);
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            ICar newCar = null;
            if (type == "Muscle")
            {
                newCar = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                newCar = new SportsCar(model, horsePower);
            }
            carRepository.Add(newCar);
            return $"{newCar.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            if (driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            IDriver newDriver = new Driver(driverName);
            driverRepository.Add(newDriver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.Models.FirstOrDefault(r => r.Name == name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            IRace race = new Race(name, laps);
            raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var sortedDrivers = driverRepository.Models.OrderByDescending(d => d.NumberOfWins).Take(3).ToList();
            if (sortedDrivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {sortedDrivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {sortedDrivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {sortedDrivers[2].Name} is third in {raceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}

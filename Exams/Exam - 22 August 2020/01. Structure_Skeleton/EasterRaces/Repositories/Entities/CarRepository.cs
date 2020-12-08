using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public CarRepository() : base()
        {
            Models = new List<ICar>();
        }

        public override ICar GetByName(string name)
        {
            return Models.FirstOrDefault(c => c.Model == name);
        }
    }
}

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public DriverRepository() : base()
        {
            Models = new List<IDriver>();
        }

        public override IDriver GetByName(string name)
        {
            return Models.FirstOrDefault(d => d.Name == name);
        }
    }
}

using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        public RaceRepository() : base()
        {
            Models = new List<IRace>();
        }

        public override IRace GetByName(string name)
        {
            return Models.FirstOrDefault(r => r.Name == name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    public interface ICommando
    {
        ICollection<IMission> Missions { get; }
    }
}

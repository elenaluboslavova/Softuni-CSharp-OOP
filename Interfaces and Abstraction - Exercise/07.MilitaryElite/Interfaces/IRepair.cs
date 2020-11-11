using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    public interface IRepair
    {
        string PartName { get; }

        int WorkedHours { get; }
    }
}

using _07.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get
            {
                return this.corps;
            }
            private set
            {
                if (value != "Marines" && value != "Airforces")
                {
                    throw new ArgumentException();
                }
                this.corps = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}");

            return sb.ToString().TrimEnd();
        }
    }
}

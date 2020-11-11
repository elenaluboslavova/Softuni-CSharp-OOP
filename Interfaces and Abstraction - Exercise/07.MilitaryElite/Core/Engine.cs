using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<ISoldier> soldiers;
        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public void Run()
        {
            Processing();
            PrintOutput(soldiers);
        }

        private void PrintOutput(ICollection<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private void Processing()
        {
            string soldier;
            while ((soldier = Console.ReadLine()) != "End")
            {
                string[] soldierArgs = soldier.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string soldierType = soldierArgs[0];
                int id = int.Parse(soldierArgs[1]);
                string firstName = soldierArgs[2];
                string lastName = soldierArgs[3];

                switch (soldierType)
                {
                    case "Private":
                        AddPrivate(soldierArgs, id, firstName, lastName);
                        break;
                    case "LieutenantGeneral":
                        AddLieitenantGeneral(soldierArgs, id, firstName, lastName);
                        break;
                    case "Engineer":
                        AddEngineer(soldierArgs, id, firstName, lastName);
                        break;
                    case "Commando":
                        AddCommando(soldierArgs, id, firstName, lastName);
                        break;
                    case "Spy":
                        AddSpy(soldierArgs, id, firstName, lastName);
                        break;
                }

            }
        }

        private void AddSpy(string[] soldierArgs, int id, string firstName, string lastName)
        {
            int codeNumer = int.Parse(soldierArgs[4]);
            Spy spy = new Spy(id, firstName, lastName, codeNumer);

            soldiers.Add(spy);
        }

        private void AddCommando(string[] soldierArgs, int id, string firstName, string lastName)
        {

            decimal salary = decimal.Parse(soldierArgs[4]);
            string corps = soldierArgs[5];
            try
            {

                Commando commando = new Commando(id, firstName, lastName, salary, corps);

                for (int i = 6; i < soldierArgs.Length; i += 2)
                {
                    string codeName = soldierArgs[i];
                    string state = soldierArgs[i + 1];
                    if (state == "inProgress" || state == "Finished")
                    {
                        Mission currentMission = new Mission(codeName, state);
                        commando.Missions.Add(currentMission);
                    }
                }
                soldiers.Add(commando);
            }
            catch (Exception)
            {

            }
        }

        private void AddEngineer(string[] soldierArgs, int id, string firstName, string lastName)
        {

            decimal salary = decimal.Parse(soldierArgs[4]);
            string corps = soldierArgs[5];
            try
            {

                Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                for (int i = 6; i < soldierArgs.Length; i += 2)
                {
                    string repairPart = soldierArgs[i];
                    int workedHours = int.Parse(soldierArgs[i + 1]);
                    Repair currentRepair = new Repair(repairPart, workedHours);
                    engineer.Repairs.Add(currentRepair);
                }

                soldiers.Add(engineer);
            }
            catch (Exception)
            {

            }

        }

        private void AddLieitenantGeneral(string[] soldierArgs, int id, string firstName, string lastName)
        {
            decimal salary = decimal.Parse(soldierArgs[4]);
            LieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);
            foreach (var privateID in soldierArgs.Skip(5))
            {
                IPrivate currentPrivate = (IPrivate)soldiers.First(x => x.Id == int.Parse(privateID));
                lieutenant.Privates.Add(currentPrivate);

            }
            soldiers.Add(lieutenant);
        }

        private void AddPrivate(string[] soldierArgs, int id, string firstName, string lastName)
        {
            decimal privateSalary = decimal.Parse(soldierArgs[4]);
            Private @private = new Private(id, firstName, lastName, privateSalary);
            soldiers.Add(@private);
        }
    }
}

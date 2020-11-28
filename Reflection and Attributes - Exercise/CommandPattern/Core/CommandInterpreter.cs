using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputInfo = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandType = inputInfo[0].ToLower();

            string[] arguments = inputInfo.Skip(1).ToArray();

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == $"{commandType}command");

            ICommand instance = (ICommand)Activator.CreateInstance(type);

            string result = instance.Execute(arguments);
            return result;
        }
    }
}

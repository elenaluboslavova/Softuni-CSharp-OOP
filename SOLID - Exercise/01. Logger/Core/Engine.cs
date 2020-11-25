using _01._Logger.Common;
using _01._Logger.Core.Contracts;
using _01._Logger.Factories;
using _01._Logger.IOManagement;
using _01._Logger.IOManagement.Contracts;
using _01._Logger.Models.Contracts;
using _01._Logger.Models.Enumerations;
using _01._Logger.Models.Errors;
using System;
using System.Globalization;
using System.Linq;

namespace _01._Logger.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;


        public Engine(ILogger logger, IReader reader, IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "END")
            {
                string[] errorArgs = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string levelStr = errorArgs[0];
                string dateTimeStr = errorArgs[1];
                string message = errorArgs[2];

                bool isLevelValid = Enum.TryParse(typeof(Level), levelStr, true, out object levelObj);

                if (!isLevelValid)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidLevelType);
                    continue;
                }

                Level level = (Level)levelObj;

                bool isDateTimeValid = DateTime.TryParseExact(dateTimeStr, GlobalConstants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

                if (!isDateTimeValid)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidDateTimeFormat);
                    continue;
                }

                IError error = new Error(dateTime, message, level);

                this.logger.Log(error);
            }

            this.writer.WriteLine(this.logger.ToString());
        }
    }
}

﻿using _01._Logger.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _01._Logger.Models
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>) this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in appenders)
            {
                if (error.Level >= appender.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (IAppender appender in this.Appenders)
            {
                sb.AppendLine(appender.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

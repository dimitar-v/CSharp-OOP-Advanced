namespace Solid.Logger.Core
{
    using Appenders.Contracts;
    using Appenders.Factory;
    using Appenders.Factory.Contracts;
    using Contracts;
    using Layouts.Contracts;
    using Layouts.Factory;
    using Layouts.Factory.Contracts;
    using Loggers.Enums;

    using System;
    using System.Collections.Generic;
    
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            appenders = new List<IAppender>();
            appenderFactory = new AppenderFactory();
            layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {

            string appenderType = args[0];
            ILayout layout = layoutFactory.CreateLayout(args[1]);
            
            IAppender appender = appenderFactory.CreateAppender(appenderType, layout);
            if (args.Length > 2)
            {
                appender.ReportLevel = Enum.Parse<ReportLevel>(args[2], true);
            }

            appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0], true);
            string time = args[1];
            string message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(time, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}

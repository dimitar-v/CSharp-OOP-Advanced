namespace Solid.Logger.Appenders
{
    using Layouts.Contracts;
    using Loggers.Enums;

    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout) { }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                MessageCount++;
                Console.WriteLine(Layout.Format, dateTime, reportLevel, message);
            }
        }

        public override string ToString()
            => $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {MessageCount}";
    }
}
namespace Solid.Logger.Loggers
{
    using Appenders.Contracts;
    using Contracts;
    using Enums;

    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }
        
        public void Info(string dateTime, string message)
            => Append(dateTime, ReportLevel.INFO, message);

        public void Warning(string dateTime, string message)
            => Append(dateTime, ReportLevel.WARNING, message);

        public void Error(string dateTime, string message)
            => Append(dateTime, ReportLevel.ERROR, message);

        public void Critical(string dateTime, string message)
            => Append(dateTime, ReportLevel.CRITICAL, message);

        public void Fatal(string dateTime, string message)
            => Append(dateTime, ReportLevel.FATAL, message);

        private void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            consoleAppender?.Append(dateTime, reportLevel, message);
            fileAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
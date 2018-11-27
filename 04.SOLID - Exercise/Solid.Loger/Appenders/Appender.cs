namespace Solid.Logger.Appenders
{
    using Contracts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Loggers.Enums;

    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            Layout = layout;
            ReportLevel = ReportLevel.INFO;
        }

        public ReportLevel ReportLevel { get; set; }
        public int MessageCount { get; protected set; }
        public ILayout Layout { get; private set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}

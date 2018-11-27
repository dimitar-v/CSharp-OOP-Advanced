namespace Solid.Logger.Appenders
{
    using Layouts.Contracts;
    using Loggers.Contracts;
    using Loggers.Enums;

    using System.IO;

    public class FileAppender : Appender
    {
        private const string path = "../../../log.txt";
        private readonly ILogFile file;

        public FileAppender(ILayout layout, ILogFile file)
            : base(layout)
        {
            this.file = file;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                MessageCount++;

                string contents = string.Format(Layout.Format, dateTime, reportLevel, message) + "\n";
                file.Write(contents);

                File.AppendAllText(path, contents);
            }
        }

        public override string ToString()
            => $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {MessageCount}, File size: {file.Size}";
    }
}

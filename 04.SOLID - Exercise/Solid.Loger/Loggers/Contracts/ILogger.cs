namespace Solid.Logger.Loggers.Contracts
{
    public interface ILogger
    {
        void Fatal(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Error(string dateTime, string message);

        void Warning(string dateTime, string message);

        void Info(string dateTime, string message);
    }
}

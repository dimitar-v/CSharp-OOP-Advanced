namespace Solid.Logger.Loggers
{
    using System.Linq;

    using Contracts;

    class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
            => Size += message.Where(char.IsLetter).Sum(x => x);
    }
}

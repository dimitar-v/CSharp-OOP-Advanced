namespace FestivalManager.Core.IO
{
    using FestivalManager.Core.IO.Contracts;
    using System;

    class ConsoleWriter : IWriter
    {
        public void Write(string contents)
            => Console.Write(contents);

        public void WriteLine(string contents)
            => Console.WriteLine(contents);
    }
}

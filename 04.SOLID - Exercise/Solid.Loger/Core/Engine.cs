namespace Solid.Logger.Core
{
    using System;

    using Contracts;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var n = int.Parse(Read());

            for (int i = 0; i < n; i++)
            {
                var args = Read().Split();

                commandInterpreter.AddAppender(args);
            }

            string input;
            while ((input = Read())?.ToLower() != "end")
            {
                var args = input.Split('|');

                commandInterpreter.AddMessage(args);
            }

            commandInterpreter.PrintInfo();
        }

        private string Read()
            => Console.ReadLine();
    }
}

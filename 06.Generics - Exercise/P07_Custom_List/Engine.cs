namespace P07_Custom_List
{
    using System;

    public class Engine
    {
        private CommandInterpreter interpreter;

        public Engine()
        {
            this.interpreter = new CommandInterpreter();
        }

        public void Run()
        {
            string input;
            while ((input = Read()) != "END")
            {
                var args = input.Split();

                interpreter.Action(args);
            }

        }

        private string Read()
            => Console.ReadLine();
    }
}

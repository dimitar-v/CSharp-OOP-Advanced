namespace P09_Custom_List_Iterator
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

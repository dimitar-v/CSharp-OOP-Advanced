namespace TheTankGame.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                var input = reader.ReadLine().Split().ToList();

                if (input[0] == "Terminate")
                {
                    isRunning = false;
                }

                string result;
                try
                {
                    result = commandInterpreter.ProcessInput(input);
                }
                catch (TargetInvocationException ex)
                {
                    result = $"ERROR: {ex.InnerException.Message}";
                }
                catch (Exception ex)
                {
                    result = $"ERROR: {ex.Message}";
                }

                writer.WriteLine(result);
            }
        }
    }
}
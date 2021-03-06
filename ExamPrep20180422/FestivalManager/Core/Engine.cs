﻿namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    using System;
    using System.Linq;
    using System.Reflection;

    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string result;

                try
                {
                    string.Intern(input);

                    result = this.CommandController(input);
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

            writer.WriteLine(festivalCоntroller.ProduceReport());
        }

        private string CommandController(string input)
        {
            string[] args = input.Split();

            string command = args[0];
            string[] parametri = args.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                return setCоntroller.PerformSets();
            }

            MethodInfo festivalcontrolfunction = festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            return (string)festivalcontrolfunction.Invoke(festivalCоntroller, new object[] { parametri });
        }
    }
}
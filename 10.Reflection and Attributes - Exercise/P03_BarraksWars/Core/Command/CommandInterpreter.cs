﻿namespace _03BarracksFactory.Core.Command
{
    using _03BarracksFactory.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == $"{commandName}command");
            IExecutable executable = (IExecutable)Activator
                .CreateInstance(type, new object[] { data, repository, unitFactory });

            return executable;
        }
    }
}

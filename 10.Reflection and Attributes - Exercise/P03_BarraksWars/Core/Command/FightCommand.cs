﻿namespace _03BarracksFactory.Core.Command
{
    using _03BarracksFactory.Contracts;
    using System;

    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        { }

        public override string Execute()
        {
            Environment.Exit(0);
            return String.Empty;
        }
    }
}

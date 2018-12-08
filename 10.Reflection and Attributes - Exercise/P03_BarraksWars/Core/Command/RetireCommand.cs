namespace _03BarracksFactory.Core.Command
{
    using _03BarracksFactory.Contracts;
    using System;

    class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        { }

        public override string Execute()
        {
            try
            {
                this.Repository.RemoveUnit(Data[1]);
                return $"{Data[1]} retired!";
            }
            catch (InvalidOperationException e)
            {
                return e.Message;
            }
        }
    }
}

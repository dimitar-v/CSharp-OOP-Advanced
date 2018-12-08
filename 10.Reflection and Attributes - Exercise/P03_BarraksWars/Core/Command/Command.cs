namespace _03BarracksFactory.Core.Command
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            Data = data;
            Repository = repository;
            UnitFactory = unitFactory;
        }

        protected string[] Data
        {
            get => data;
            private set => data = value;
        }
        protected IRepository Repository
        {
            get => repository;
            private set => repository = value;
        }
        protected IUnitFactory UnitFactory
        {
            get => unitFactory;
            private set => unitFactory = value;
        }

        public abstract string Execute();
    }
}

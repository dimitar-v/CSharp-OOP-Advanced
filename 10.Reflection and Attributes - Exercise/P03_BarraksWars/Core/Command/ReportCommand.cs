namespace _03BarracksFactory.Core.Command
{
    using _03BarracksFactory.Contracts;

    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        { }

        public override string Execute()
            => this.Repository.Statistics;
    }
}

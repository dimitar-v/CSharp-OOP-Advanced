namespace FestivalManager
{
    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            IStage stage = new Stage();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IFestivalController festivalController = new FestivalController(stage, new InstrumentFactory(), new SetFactory());
            ISetController setController = new SetController(stage);

            IEngine engine = new Engine(reader, writer, festivalController, setController);
            engine.Run();
        }
    }
}
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Sets;
using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities.Instruments;
// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{

    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
        private IStage stage;
        private ISet set;
        private ISetController setController;
        private IPerformer performer;
        private ISong song;
        private IInstrument instrument;


        [SetUp]
        public void Setup()
        {
            stage = new Stage();
            set = new Short("ShortSet");
            stage.AddSet(set);
            setController = new SetController(stage);

            performer = new Performer("Pesho", 18);
            instrument = new Guitar();
            performer.AddInstrument(instrument);

            song = new Song("Song", new TimeSpan(0, 2, 30));
        }

        [Test]
	    public void SetControllerShouldReturnFailMessage()
	    {
            string expectedResult = "1. ShortSet:\r\n-- Did not perform";
            string actualResult = setController.PerformSets();

            Assert.AreEqual(expectedResult, actualResult, "Not return fail message");
		}

        [Test]
        public void SetControllerShouldReturnSucessMessage()
        {
            set.AddSong(song);
            set.AddPerformer(performer);

            string expectedResult = "1. ShortSet:\r\n-- 1. Song (02:30)\r\n-- Set Successful";
            string actualResult = setController.PerformSets();

            Assert.AreEqual(expectedResult, actualResult, "Not return sucess message");
        }

        [Test]
        public void PerformSetShouldDecraseInstrumentWear()
        {
            set.AddSong(song);
            set.AddPerformer(performer);

            double instrumentWearBefore = instrument.Wear - 60;

            setController.PerformSets();

            double instrumentWearAfter = instrument.Wear;

            Assert.AreEqual(instrumentWearBefore, instrumentWearAfter, "Instrument wear not changed");
        }
    }
}
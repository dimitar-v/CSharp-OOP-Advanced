// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;

    using Travel.Entities;
    using Travel.Entities.Contracts;
    using Travel.Core.Controllers.Contracts;
    using Travel.Core.Controllers;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
        private IAirport airport;
        private IFlightController flightController;
        private IAirplane airplane;
        private ITrip trip;
        private ITrip tripComplated;
        private IPassenger[] passengers;
        
        private IBag bag;

        [SetUp]
        public void Setup()
        {
            airport = new Airport();
            flightController = new FlightController(airport);
            tripComplated = new Trip("London", "Sofia", new MediumAirplane());
            tripComplated.Complete();
            airplane = new LightAirplane();
            trip = new Trip("Sofia", "London", airplane);
        }

	    [Test]
	    public void TestIsTakeOffMethodWorkProperly()
	    {
            // test is Complated not fly
            airport.AddTrip(tripComplated);

            passengers = new Passenger[10];


            // test if airplane is overbooked
            // test load carry on baggage
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Ivan" + i);

                if (i % 2 == 0)
                {
                    bag = new Bag(passengers[i], new Item[] { new Laptop() });
                    passengers[i].Bags.Add(bag);
                }

                trip.Airplane.AddPassenger(passengers[i]);
            }

            airport.AddTrip(trip);

            string expectedResult = "SofiaLondon2:\r\nOverbooked! Ejected Ivan1, Ivan0, Ivan3, Ivan7, Ivan8\r\nConfiscated 2 bags ($6000)\r\nSuccessfully transported 5 passengers from Sofia to London.\r\nConfiscated bags: 2 (2 items) => $6000";
            string actualResult = flightController.TakeOff();

            Assert.AreEqual(expectedResult, actualResult);
            // test trip is changed to complated
            Assert.AreEqual(true, trip.IsCompleted);
	    }
    }
}

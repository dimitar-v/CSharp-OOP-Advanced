namespace Travel.Core.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Entities;
	using Entities.Contracts;
	using Entities.Factories;
	using Entities.Factories.Contracts;
    using Entities.Items.Contracts;

    public class AirportController : IAirportController
	{
        private const int BagValueConfiscationThreshold = 3000;

		private IAirport airport;

		private IAirplaneFactory airplaneFactory;
		private IItemFactory itemFactory;

		public AirportController(IAirport airport)
		{
			this.airport = airport;
			this.airplaneFactory = new AirplaneFactory();
			this.itemFactory = new ItemFactory();
		}

        // Done
		public string RegisterPassenger(string username)
		{
			if (this.airport.GetPassenger(username) != null)
			{
				throw new InvalidOperationException($"Passenger {username} already registered!");
			}

			var passenger = new Passenger(username);

			this.airport.AddPassenger(passenger);

			return $"Registered {passenger.Username}";
		}

        // Done
        public string RegisterTrip(string source, string destination, string planeType)
        {
            var airplane = airplaneFactory.CreateAirplane(planeType);

            var trip = new Trip(source, destination, airplane);

            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
        }

        // Done
        public string RegisterBag(string username, IEnumerable<string> bagItems)
		{
            IPassenger passenger = this.airport.GetPassenger(username);

			IItem[] items = bagItems.Select(i => itemFactory.CreateItem(i)).ToArray();
            IBag bag = new Bag(passenger, items);

			passenger.Bags.Add(bag);

			return $"Registered bag with {string.Join(", ", bagItems)} for {username}";
		}
        
        // Done
		public string CheckIn(string username, string tripId, IEnumerable<int> bagIndices)
		{
            bool checkedIn = airport.Trips.Any(t => t.Airplane.Passengers.Any(p => p.Username == username));

			if (checkedIn)
			{
				throw new InvalidOperationException($"{username} is already checked in!");
			}

            IPassenger passenger = airport.GetPassenger(username);
            ITrip trip = airport.GetTrip(tripId);

            int confiscatedBags = CheckInBags(passenger, bagIndices);
			trip.Airplane.AddPassenger(passenger);

			return
				$"Checked in {passenger.Username} with {bagIndices.Count() - confiscatedBags}/{bagIndices.Count()} checked in bags";
		}

        // Done
		private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIn)
		{
            IList<IBag> bags = passenger.Bags;

            int confiscatedBagCount = 0;
			foreach (int bagIndex in bagsToCheckIn)
			{
                IBag currentBag = bags[bagIndex];
				bags.RemoveAt(bagIndex);

				if (ShouldConfiscate(currentBag))
				{
					airport.AddConfiscatedBag(currentBag);
					confiscatedBagCount++;
				}
				else
				{
					this.airport.AddCheckedBag(currentBag);
				}
			}

			return confiscatedBagCount;
		}

        // Done
		private static bool ShouldConfiscate(IBag bag)
		{
            int luggageValue = 0;
            IItem[] items = bag.Items.ToArray();

            for (int i = 0; i < items.Length; i++)
			{
				luggageValue += items[i].Value;
			}

            return luggageValue > BagValueConfiscationThreshold;
		}
	}
}
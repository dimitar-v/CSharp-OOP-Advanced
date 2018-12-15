namespace Travel.Core.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using Contracts;
	using Entities.Contracts;

	public class FlightController : IFlightController
	{
		private const int EjectionSeed = 1337;

		private readonly IAirport airport;

		private readonly Random randomGenerator;

		public FlightController(IAirport airport)
		{
			this.airport = airport;

			this.randomGenerator = new Random(EjectionSeed);
		}

		public string TakeOff()
		{
            StringBuilder sb = new StringBuilder();

			foreach (ITrip trip in this.airport.Trips)
			{
				if (trip.IsCompleted)
				{
					continue;
				}

				sb.AppendLine($"{trip.Id}:");

				LoadCarryOnBaggage(trip);

				if (trip.Airplane.IsOverbooked)
				{
                    IEnumerable<IPassenger> ejectedPassengers = EjectOverbookedPassengers(trip);
					sb.AppendLine($"Overbooked! Ejected {string.Join(", ", ejectedPassengers.Select(ep => ep.Username))}");

                    IBag[] ejectedBags = ejectedPassengers
						.SelectMany(ep => trip.Airplane.EjectPassengerBags(ep))
						.ToArray();

					foreach (IBag bag in ejectedBags)
					{
						this.airport.AddConfiscatedBag(bag);
					}

					var bagsTotalValue = ejectedBags.SelectMany(b => b.Items).Sum(i => i.Value);
					sb.AppendLine($"Confiscated {ejectedBags.Length} bags (${bagsTotalValue})");
				}

				trip.Complete();

				sb.AppendLine(string.Format("Successfully transported {0} passengers from {1} to {2}.",
                    trip.Airplane.Passengers.Count,
                    trip.Source,
                    trip.Destination
                    ));
			}

			var confiscatedBags = this.airport.ConfiscatedBags;
            var confiscatedItems = confiscatedBags.SelectMany(b => b.Items).ToArray();
			var confiscatedItemsSum = confiscatedItems.Sum(i => i.Value);

			sb.AppendLine(string.Format("Confiscated bags: {0} ({1} items) => ${2}",
				confiscatedBags.Count,
				confiscatedItems.Length,
				confiscatedItemsSum
			    ));

			return sb.ToString().TrimEnd('\r', '\n');
		}

		private static void LoadCarryOnBaggage(ITrip trip)
		{
			var plane = trip.Airplane;
			foreach (IPassenger passenger in plane.Passengers)
			{
                IList<IBag> luggage = passenger.Bags;
				for (int bagIndex = 0; bagIndex < luggage.Count; bagIndex++)
				{
                    IBag luggageBag = luggage[bagIndex];

					passenger.Bags.RemoveAt(bagIndex);

					plane.LoadBag(luggageBag);
				}
			}
		}

		private IEnumerable<IPassenger> EjectOverbookedPassengers(ITrip trip)
		{
			var plane = trip.Airplane;

			var ejectedPassengers = new List<IPassenger>();

			while (plane.IsOverbooked)
			{
				var seat = this.randomGenerator.Next(plane.Seats);
				var passenger = plane.RemovePassenger(seat);

				ejectedPassengers.Add(passenger);
			}

			return ejectedPassengers;
		}
	}
}
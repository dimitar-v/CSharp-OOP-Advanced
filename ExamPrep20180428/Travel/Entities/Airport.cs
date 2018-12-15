namespace Travel.Entities
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Airport : IAirport
    {
        private List<IBag> checkedInBags;
        private List<IBag> confiscatedBags;
        private List<ITrip> trips;
        private List<IPassenger> passengers;

        public Airport()
        {
            checkedInBags = new List<IBag>();
            confiscatedBags = new List<IBag>();
            trips = new List<ITrip>();
            passengers = new List<IPassenger>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => checkedInBags.AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => confiscatedBags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => passengers.AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => trips.AsReadOnly();

        public IPassenger GetPassenger(string username) => passengers.FirstOrDefault(p => p.Username == username);

        public ITrip GetTrip(string id) => trips.FirstOrDefault(t => t.Id == id);

        public void AddPassenger(IPassenger passenger) => passengers.Add(passenger);

        public void AddTrip(ITrip trip) => trips.Add(trip);

        public void AddCheckedBag(IBag bag) => checkedInBags.Add(bag);

        public void AddConfiscatedBag(IBag bag) => confiscatedBags.Add(bag);
    }
}
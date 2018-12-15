namespace Travel.Entities.Airplanes
{
    using Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> bags;
        private List<IPassenger> passangers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
            this.passangers = new List<IPassenger>();
            this.bags = new List<IBag>();
        }

        public int Seats { get; }

        public int BaggageCompartments { get; }

        public IReadOnlyCollection<IBag> BaggageCompartment => bags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => passangers.AsReadOnly();

        public bool IsOverbooked => Passengers.Count > Seats;

        public void AddPassenger(IPassenger passenger) => passangers.Add(passenger);

        public IPassenger RemovePassenger(int seat)
        {
            // TODO: Check seat - 1 ?
            IPassenger passenger = passangers[seat];

            passangers.RemoveAt(seat);

            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            IBag[] passengerBags = this.bags
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (IBag bag in passengerBags)
            {
                this.bags.Remove(bag);
            }

            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            // TODO: check this >= ?
            bool isBaggageCompartmentFull = this.bags.Count > this.BaggageCompartments;
            if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name.ToString()}!");
            }

            this.bags.Add(bag);
        }
    }
}
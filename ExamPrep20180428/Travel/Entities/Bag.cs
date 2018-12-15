namespace Travel.Entities
{
    using Contracts;
    using Items.Contracts;
    using System.Collections.Generic;

    public class Bag : IBag
    {
        private List<IItem> items;

        public Bag(IPassenger owner, IEnumerable<IItem> items)
        {
            this.Owner = owner;
            this.items = new List<IItem>(items);
        }

        public IPassenger Owner { get; }

        public IReadOnlyCollection<IItem> Items => this.items.AsReadOnly();
    }
}
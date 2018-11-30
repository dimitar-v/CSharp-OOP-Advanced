namespace P07_Custom_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CustomList<T> : ICustomList<T>
        where T : IComparable
    {
        private IList<T> list;

        public CustomList()
        {
            this.list = new List<T>();
        }

        public T Max => list.Max();

        public T Min => list.Min();

        public void Add(T element)
            => list.Add(element);

        public bool Contains(T element)
            => list.Contains(element);

        public int CountGreaterThan(T element)
            => list.Count(e => e.CompareTo(element) > 0);

        public T Remove(int index)
        {
            T removed = list[index];
            list.RemoveAt(index);
            return removed;
        }

        public void Swap(int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public override string ToString()
            => string.Join(Environment.NewLine, list);
    }
}

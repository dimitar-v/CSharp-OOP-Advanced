namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private IList<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public int Count => list.Count;

        public void Add(T element)
        {
            list.Add(element);
        }

        public T Remove()
        {
            T removed = list[Count - 1];
            list.RemoveAt(Count - 1);
            return removed;
        }

    }
}

namespace P09_Custom_List_Iterator
{
    using System.Collections.Generic;

    public interface ICustomList<T> : IEnumerable<T>
    {
        T Max { get; }
        T Min { get; }

        void Add(T element);
        T Remove(int index);
        bool Contains(T element);
        void Swap(int index1, int index2);
        int CountGreaterThan(T element);
        void Sort();
    }
}

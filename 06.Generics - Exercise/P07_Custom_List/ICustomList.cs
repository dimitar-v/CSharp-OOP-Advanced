namespace P07_Custom_List
{
    public interface ICustomList<T>
    {
        T Max { get; }
        T Min { get; }

        void Add(T element);
        T Remove(int index);
        bool Contains(T element);
        void Swap(int index1, int index2);
        int CountGreaterThan(T element);
    }
}

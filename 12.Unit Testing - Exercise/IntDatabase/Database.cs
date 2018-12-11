namespace IntDatabase
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int Capacity = 16;

        private int[] data;
        private int index;

        public Database()
        {
            data = new int[Capacity];
            index = -1;
        }

        public Database(int[] value)
            : this()
        {
            HasCapacity(value.Length - 1, "Not enough capacity!");

            index = value.Length - 1;

            for (int i = 0; i <= index; i++)
            {
                data[i] = value[i];
            }
        }

        public void Add(int value)
        {
            HasCapacity(index + 1, "Not enough capacity!");

            data[++index] = value;
        }

        public void Remove()
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            data[index--] = 0;
        }

        public int[] Fetch()
            => data.Take(index + 1).ToArray();

        private void HasCapacity(int length, string message)
        {
            if (length >= Capacity)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}

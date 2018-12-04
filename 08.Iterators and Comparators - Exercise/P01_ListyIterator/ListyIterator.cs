namespace P01_ListyIterator
{
    using System;


    public class ListyIterator<T>
    {
        private int currentIndex;
        private readonly T[] elements;

        public ListyIterator(params T[] elements)
        {
            this.elements = elements;
            currentIndex = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
            => currentIndex + 1 < elements.Length;

        public void Print()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(elements[currentIndex]);
        }

    }
}

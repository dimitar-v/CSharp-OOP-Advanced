namespace P06_Generic_Count_Method_Double
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T> 
        where T : IComparable
    {
        private List<T> items;

        public Box(List<T> items)
        {
            this.items = items;
        }

        public void Swap(int index1, int index2)
        {
            var temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        public int Count(T compareItem)
        {
            var count = 0;

            foreach (var item in items)
            {
                if (item.CompareTo(compareItem) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}

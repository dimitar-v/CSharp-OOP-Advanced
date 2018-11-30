namespace P03_Generic_Swap_Method_String
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
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

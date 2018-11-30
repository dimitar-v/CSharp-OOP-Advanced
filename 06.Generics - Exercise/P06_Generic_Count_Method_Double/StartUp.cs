namespace P06_Generic_Count_Method_Double
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var items = new List<double>();

            for (int i = 0; i < n; i++)
            {
                var item = double.Parse(Console.ReadLine());

                items.Add(item);
            }

            var compareItem = double.Parse(Console.ReadLine());

            var box = new Box<double>(items);

            Console.WriteLine(box.Count(compareItem));
        }
    }
}

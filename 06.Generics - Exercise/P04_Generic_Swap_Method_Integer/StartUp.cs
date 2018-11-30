namespace P04_Generic_Swap_Method_Integer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var items = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var item = int.Parse(Console.ReadLine());

                items.Add(item);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var box = new Box<int>(items);
            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}

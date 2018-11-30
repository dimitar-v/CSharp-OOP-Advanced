namespace P05_Generic_Count_Method_String
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var items = new List<String>();

            for (int i = 0; i < n; i++)
            {
                var item = (Console.ReadLine());

                items.Add(item);
            }

            var compareItem = Console.ReadLine();

            var box = new Box<string>(items);
            
            Console.WriteLine(box.Count(compareItem));
        }
    }
}

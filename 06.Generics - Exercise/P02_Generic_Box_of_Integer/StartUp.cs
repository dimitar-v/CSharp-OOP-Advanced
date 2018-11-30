using System;

namespace P02_Generic_Box_of_Integer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var item = int.Parse(Console.ReadLine());

                var box = new Box<int>(item);

                Console.WriteLine(box);
            }
        }
    }
}

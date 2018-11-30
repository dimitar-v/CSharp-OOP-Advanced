using System;

namespace P01_Generic_Box_of_String
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var item = (Console.ReadLine());

                var box = new Box<string>(item);

                Console.WriteLine(box);
            }
        }
    }
}

using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var compare = new Scale<int>(7, 9);

            Console.WriteLine(compare.GetHeavier());
        }
    }
}

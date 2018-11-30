using System;

namespace P10_Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();

            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var address = personInfo[2];

            var beearInfo = Console.ReadLine().Split();

            var name = beearInfo[0];
            var beer = int.Parse(beearInfo[1]);
            
            var nums = Console.ReadLine().Split();

            var i = int.Parse(nums[0]);
            var d = double.Parse(nums[1]);

            CustomTuple<int, double> specialTuple = new CustomTuple<int, double>(i, d);
            CustomTuple<string, int> beerTuple = new CustomTuple<string, int>(name, beer);
            CustomTuple<string, string> person = new CustomTuple<string, string>(fullName, address);

            Console.WriteLine(person);
            Console.WriteLine(beerTuple);
            Console.WriteLine(specialTuple);
        }
    }
}

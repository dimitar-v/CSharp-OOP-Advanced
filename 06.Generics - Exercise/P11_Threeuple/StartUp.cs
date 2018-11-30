using System;

namespace P11_Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();

            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var address = personInfo[2];
            var town = personInfo[3];

            var beearInfo = Console.ReadLine().Split();

            var name = beearInfo[0];
            var beer = int.Parse(beearInfo[1]);
            var isDrunk = beearInfo[2] == "drunk";

            var bank = Console.ReadLine().Split();

            var accaunt = bank[0];
            var balance = double.Parse(bank[1]);
            var bankName = bank[2];

            CustomTuple<string, string, string> person = new CustomTuple<string, string, string>(fullName, address, town);
            CustomTuple<string, int, bool> beerTuple = new CustomTuple<string, int, bool>(name, beer, isDrunk);
            CustomTuple<string, double, string> bankTuple = new CustomTuple<string, double, string>(accaunt, balance, bankName);

            Console.WriteLine(person);
            Console.WriteLine(beerTuple);
            Console.WriteLine(bankTuple);
        }
    }
}

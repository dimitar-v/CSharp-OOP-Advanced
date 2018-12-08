namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            var blackBox = (BlackBoxInteger)Activator.CreateInstance(type, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split("_");

                var command = args[0];
                var value = int.Parse(args[1]);

                var method = type
                    .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(m => m.Name == command);

                method.Invoke(blackBox, new object[] { value });

                var result =  type
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(m => m.Name == "innerValue")
                    .GetValue(blackBox);

                Console.WriteLine(result);
            }
        }
    }
}

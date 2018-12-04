namespace P04_Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] stones = Read().Split(", ")
                .Select(int.Parse)
                .ToArray();

            Lake<int> lake = new Lake<int>(stones);

            Write(string.Join(", ", lake));
        }

        private static string Read()
            => Console.ReadLine();

        private static void Write(string message)
            => Console.WriteLine(message);
    }
}

using System;

namespace Sandbox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            TimeSpan time = new TimeSpan(0,1,5);

            int minutes = time.Hours * 60 + time.Minutes;
            int seconds = time.Seconds;

            Console.WriteLine($"{minutes:d2}:{seconds:d2}");
        }
    }
}

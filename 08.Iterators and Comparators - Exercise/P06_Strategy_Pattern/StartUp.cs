namespace P06_Strategy_Pattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> byName = new SortedSet<Person>(new NameComparator()); 
            SortedSet<Person> byAge = new SortedSet<Person>(new AgeComparator()); 

            var n = int.Parse(Read());
            for (int i = 0; i < n; i++)
            {
                var info = Read().Split();
                var name = info[0];
                var age = int.Parse(info[1]);

                Person person = new Person(name, age);

                byName.Add(person);
                byAge.Add(person);
            }

            Write(string.Join(Environment.NewLine, byName));
            Write(string.Join(Environment.NewLine, byAge));
        }

        private static string Read()
            => Console.ReadLine();

        private static void Write(string message)
            => Console.WriteLine(message);
    }
}

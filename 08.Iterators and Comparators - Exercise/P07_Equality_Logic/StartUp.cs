namespace P07_Equality_Logic
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> hashedPeople = new HashSet<Person>();

            var n = int.Parse(Read());
            for (int i = 0; i < n; i++)
            {
                var info = Read().Split();
                var name = info[0];
                var age = int.Parse(info[1]);

                Person person = new Person(name, age);

                sortedPeople.Add(person);
                hashedPeople.Add(person);
            }

            Write(hashedPeople.Count.ToString());
            Write(sortedPeople.Count.ToString());
        }

        private static string Read()
            => Console.ReadLine();

        private static void Write(string message)
            => Console.WriteLine(message);
    }
}

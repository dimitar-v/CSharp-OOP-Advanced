namespace P05_Comparing_Objects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Read()) != "END")
            {
                var info = input.Split();
                var name = info[0];
                var age = int.Parse(info[1]);
                var town = info[2];

                people.Add(new Person(name, age, town));
            }

            var index = int.Parse(Read()) - 1;
            var searchPerson = people[index];

            var equalPeople = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(searchPerson) == 0)
                {
                    equalPeople++;
                }
            }

            Write(equalPeople == 1 ? "No matches" : $"{equalPeople} {people.Count - equalPeople} {people.Count}");
        }

        private static string Read()
            => Console.ReadLine();

        private static void Write(string message)
            => Console.WriteLine(message);
    }
}

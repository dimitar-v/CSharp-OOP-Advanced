namespace P06_Strategy_Pattern
{
    using System.Collections.Generic;

    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
            => x.Age.CompareTo(y.Age);
    }
}

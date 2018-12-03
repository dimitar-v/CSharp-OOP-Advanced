namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;

    internal interface IBook : IComparable<Book>
    {
        string Title { get; }
        int Year { get; }
        IReadOnlyCollection<string> Authors { get; }
    }
}

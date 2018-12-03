namespace IteratorsAndComparators
{
    using System.Collections.Generic;

    public class Book : IBook
    {
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            this.authors = new List<string>(authors);
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyCollection<string> Authors => authors.AsReadOnly();

        public int CompareTo(Book other)
        {
            int result = Year.CompareTo(other.Year);

            if (result == 0)
            {
                result = Title.CompareTo(other.Title);
            }

            return result;
        }

        public override string ToString()
            => $"{Title} - {Year}";
    }
}

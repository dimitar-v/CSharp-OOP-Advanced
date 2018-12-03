namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            books.Sort(new BookComparator());
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(List<Book> books)
            {
                Reset();
                this.books = books;
            }

            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            { }

            public bool MoveNext()
                => ++currentIndex < books.Count;

            public void Reset()
                => currentIndex = -1;
        }
    }
}

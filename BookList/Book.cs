using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public Book() { }

        public Book(string author, string title, string publisher)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
        }

        public bool Equals(Book other)
        {
            if (other == null)
                throw new ArgumentException();
            return ToString().Equals(other.ToString());
        }

        public int CompareTo(Book other)
        {
            if (other == null)
                throw new ArgumentException();
            return Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", Author, Title, Publisher);
        }
    }
}

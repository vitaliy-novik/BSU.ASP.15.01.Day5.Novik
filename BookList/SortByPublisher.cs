using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList
{
    public sealed class SortByPublisher : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Publisher.CompareTo(y.Publisher);
        }
    }
}

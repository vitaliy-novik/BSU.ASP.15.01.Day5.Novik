using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList
{
    public sealed class SortByTitle : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList
{
    public interface IBookListService
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        IEnumerable<Book> FindByTag(string author = "", string title = "", string publisher = "");
        void SortBooksByTag(IComparer<Book> comparer);
    }
}

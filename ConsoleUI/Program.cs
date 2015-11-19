using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookList;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService bs = new BookListService();
            bs.AddBook(new Book()
            {
                Author = "Dino Esposito",
                Title = "Programming Microsoft ASP.NET 4",
                Publisher = "Microsoft Press"
            });
            bs.AddBook(new Book()
            {
                Author = "Jeffrey Richter",
                Title = "CLR via C#",
                Publisher = "Microsoft Press"
            });
            bs.AddBook(new Book()
            {
                Author = "Joseph Albahary, Ben Albahary",
                Title = "C# 5.0 in a Nutshell",
                Publisher = "O'Reilly"
            });
            bs.Write(new LinqToXMLSource("books.xml"));
            bs.Clear();
            bs.Reed(new LinqToXMLSource("books.xml"));
            bs.SerializeInXml("sbooks.xml");
            bs = BookListService.DeserializeInXML("sbooks.xml");
            foreach (Book book in bs)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            IEnumerable<Book> books = bs.FindByTag(title: "c#");
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            bs.SortBooksByTag(new SortByTitle());
            foreach (Book book in bs)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            Console.Read();
        }
    }
}
